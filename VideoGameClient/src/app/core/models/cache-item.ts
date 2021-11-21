import { Observable } from "rxjs";

export interface CacheItem<T>{
    expires: number;
    data: T | null;
    pendingRequest: Observable<T> | null;
}