import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { GameType } from '../models/enums';
import { Platform } from '../models/platform';
import { Publisher } from '../models/publisher';
import { VideoGame } from '../models/video-game';
import { Option } from '../models/option';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class VideoGameService {
  private readonly VIDEO_GAME_URL = '/api/VideoGame';
  constructor(private apiService: ApiService) { }

  public getVideoGames(): Observable<VideoGame[]>{
    let a: VideoGame[] = [
      {
        id: 1,
        name: 'Iris.Fall',
        description: 'A puzzle adventure game featuring striking visuals and a spellbinding theme of "light and shadow".',
        platforms: [
                    {
                      id: 1,
                      name: 'PS4'
                    },
                    {
                      id: 2,
                      name: 'XBO'
                    }
                  ],
        publisher: {
          id: 1,
          name: 'PM Studios'
        },
        gameType: GameType.Online
      },
      {
        id: 2,
        name: 'Ride 4',
        description: 'A motorcycle racing video game.',
        platforms: [
                    {
                      id: 3,
                      name: 'PS5'
                    },
                    {
                      id: 4,
                      name: 'XSX'
                    }
                  ],
        publisher: {
          id: 2,
          name: 'Milestone'
        },
        gameType: GameType.Multiple
      },
      {
        id: 3,
        name: 'The Medium',
        description: 'A psychological horror video game.',
        platforms: [
                    {
                      id: 5,
                      name: 'Win'
                    },
                    {
                      id: 4,
                      name: 'XSX'
                    }
                  ],
        publisher: {
          id: 3,
          name: 'Bloober Team SA'
        },
        gameType: GameType.Single
      }
    ];
    return of(a); 
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
    let a: Publisher[] = [{
      id: 1,
      name: 'PM Studios'
    },
    {
      id: 2,
      name: 'Milestone'
    },
    {
      id: 3,
      name: 'Bloober Team SA'
    }]
    return of(a); 
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
}
