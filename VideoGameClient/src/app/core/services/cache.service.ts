import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { share, tap } from 'rxjs/operators'
import { CacheItem } from '../models/cache-item';

@Injectable({
  providedIn: 'root'
})
export class CacheService {
  private readonly _cache: { [key: string]: CacheItem<any> } = {};
  private readonly _expires = Date.now() + (1000 * 30) / 2;
  tryGet<T>(key: string, fetchHandler: Observable<T>, forceReload = false): Observable<T>{
    let cachedItem: CacheItem<T> = this._cache[key] as CacheItem<T>;
    if(!cachedItem){
      cachedItem = {expires: this._expires, data: null, pendingRequest: null};
      this._cache[key] = cachedItem;
    }
    if(!forceReload && cachedItem.data && cachedItem.expires >= Date.now()){
      return of(cachedItem.data);
    }
    if(cachedItem.pendingRequest && cachedItem.expires >= Date.now()){
      return cachedItem.pendingRequest;
    }
    cachedItem.pendingRequest = fetchHandler.pipe(
      tap(
        (data: T) => {
          cachedItem.data = data;
          cachedItem.pendingRequest = null;
        },
        () => (cachedItem.pendingRequest = null)
      ),
      share()
    );
    return cachedItem.pendingRequest;
  }
}