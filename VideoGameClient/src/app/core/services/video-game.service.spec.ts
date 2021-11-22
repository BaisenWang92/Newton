import { fakeAsync, TestBed, tick } from '@angular/core/testing';
import { ApiService } from './api.service';
import { CacheService } from './cache.service';
import { VideoGameService } from './video-game.service';
import { MockProvider } from 'ng-mocks';
import { EMPTY } from 'rxjs';
import { VideoGameUpdateRequest } from '../models/video-game-update-request';
import { GameType } from '../models/enums';

describe('VideoGameService', () => {
  let videoGameService: VideoGameService;
  let apiService: ApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        VideoGameService,
        MockProvider(ApiService, {
          get: () => EMPTY,
          put: () => EMPTY
        }),
        MockProvider(CacheService, {
          tryGet: () => EMPTY
        })
      ]
    });
    videoGameService = TestBed.inject(VideoGameService);
    apiService = TestBed.inject(ApiService);
  });

  it('should be created', () => {
    expect(videoGameService).toBeTruthy();
  });

  it('get platforms', () => {
    const getSpy: jasmine.Spy = spyOn(apiService, 'get');
    videoGameService.getPlatforms();
    expect(getSpy).toHaveBeenCalledWith('/api/VideoGame/getPlatforms');
  });

  it('get publishers', () => {
    const getSpy: jasmine.Spy = spyOn(apiService, 'get');
    videoGameService.getPublishers();
    expect(getSpy).toHaveBeenCalledWith('/api/VideoGame/getPublishers');
  });

  it('get videogames', () => {
    const getSpy: jasmine.Spy = spyOn(apiService, 'get');
    videoGameService.getVideoGames();
    expect(getSpy).toHaveBeenCalledWith('/api/VideoGame/getVideoGames');
  });

  it('save', () => {
    const getSpy: jasmine.Spy = spyOn(apiService, 'put');
    let videoGameUpdateRequest: VideoGameUpdateRequest ={
      id: 1,
      name: "testName",
      description: "testDescription",
      platformIds: [1, 2],
      publisherId: 1,
      gameType: GameType.Single
    }
    videoGameService.save(videoGameUpdateRequest.id, 
      videoGameUpdateRequest.name, 
      videoGameUpdateRequest.description, 
      [{key: 1, value: "test1"}, {key: 2, value: "test2"}], 
      videoGameUpdateRequest.publisherId, 
      videoGameUpdateRequest.gameType);
    expect(getSpy).toHaveBeenCalledWith('/api/VideoGame/update', videoGameUpdateRequest);
  });
});

