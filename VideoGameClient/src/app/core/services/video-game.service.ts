import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { GameType } from '../models/enums';
import { Platform } from '../models/platform';
import { Publisher } from '../models/publisher';
import { VideoGame } from '../models/video-game';
import { Option } from '../models/option';
import { ApiService } from './api.service';
import { VideoGameUpdateRequest } from '../models/video-game-update-request';

@Injectable({
  providedIn: 'root'
})
export class VideoGameService {
  private readonly VIDEO_GAME_URL = '/api/VideoGame';
  constructor(private apiService: ApiService) { }

  public getVideoGames(): Observable<VideoGame[]>{
    return this.apiService.get<VideoGame[]>(this.VIDEO_GAME_URL + '/getVideoGames')
  }

  public getPlatforms(): Observable<Platform[]>{
    return this.apiService.get<Platform[]>(this.VIDEO_GAME_URL + '/getPlatforms');
  }

  public platformListToOptions(platforms: Platform[]): Option[]{
    if(platforms){
      return platforms.map(platform => {
        return {
          key: platform.id,
          value: platform.name
        }
      })
    }
    else{
      return [];
    }
  }

  public getPublishers(): Observable<Publisher[]>{
    return this.apiService.get<Platform[]>(this.VIDEO_GAME_URL + '/getPublishers');
  }

  public publisherListToOptions(publishers: Publisher[]): Option[]{
    if(publishers){
      return publishers.map(publisher => {
        return {
          key: publisher.id,
          value: publisher.name
        }
      })
    }
    else{
      return [];
    }
  }

  public getGameTypes(): GameType[]{
    let res = [];
    for (let element in GameType) {
      if (!isNaN(Number(element))) {
        res.push(element);
      }
    }
    return res; 
  }

  public gameTypeListToOptions(gameTypes: GameType[]): Option[]{
    if(gameTypes){
      return gameTypes.map(gameType => {
        return {
          key: gameType,
          value: GameType[gameType]
        }
      })
    }
    else{
      return [];
    }
  }

  public save(id: number, name: string, description: string,
    platformOptions: Option[], publisherId: number, gameType: GameType){
    let videoGameUpdateRequest: VideoGameUpdateRequest ={
      id: id,
      name: name,
      description: description,
      platformIds: platformOptions.map(platformOption => platformOption.key as number),
      publisherId: publisherId,
      gameType: gameType
    }
    return this.apiService.put<void>(this.VIDEO_GAME_URL + '/update', videoGameUpdateRequest);
  }
}
