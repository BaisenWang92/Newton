using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameServer.Core.Models;

namespace VideoGameServer.Core.Services
{
    public class VideoGameService : IVideoGameService
    {
        private readonly ICacheService _cacheService;
        private bool clearVideoGames = false;
        public VideoGameService(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public IEnumerable<Platform> GetPlatforms(VideoGameDbContext videoGameDbContext)
        {
            const string key = "PLATFORMS";
            return _cacheService.Get<IEnumerable<Platform>>(key, () => { return videoGameDbContext.Platforms.ToArray(); });
        }

        public IEnumerable<Publisher> GetPublishers(VideoGameDbContext videoGameDbContext)
        {
            const string key = "PUBLISHERS";
            return _cacheService.Get<IEnumerable<Publisher>>(key, () => { return videoGameDbContext.Publishers.ToArray(); });
        }

        public IEnumerable<VideoGameResponse> GetVideoGames(VideoGameDbContext videoGameDbContext)
        {
            const string key = "VIDEO_GAMES";
            IEnumerable<VideoGameResponse> res =
                _cacheService.Get<IEnumerable<VideoGameResponse>>(key, () => {
                    return videoGameDbContext.VideoGames
                        .Include(x => x.Publisher)
                        .Include(x => x.VideoGamePlatforms)
                        .ThenInclude(x => x.Platform)
                        .Select(x => new VideoGameResponse()
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Description = x.Description,
                            Platforms = x.VideoGamePlatforms.Select(y => y.Platform),
                            Publisher = x.Publisher,
                            GameType = x.GameType
                        })
                        .ToArray();
                }, clearVideoGames);
            if (clearVideoGames == true)
            {
                clearVideoGames = false;
            }
            return res;
        }

        public void Update(VideoGameDbContext videoGameDbContext, VideoGameUpdateRequest videoGameUpdateRequest)
        {
            clearVideoGames = true;
            VideoGame videoGame =
                videoGameDbContext
                .VideoGames
                .Include(x => x.VideoGamePlatforms)
                .FirstOrDefault(item => item.Id == videoGameUpdateRequest.Id);
            if (videoGame == null)
            {
                throw new ArgumentException("Cannot find the video game!");
            }
            videoGame.Name = videoGameUpdateRequest.Name;
            videoGame.Description = videoGameUpdateRequest.Description;
            videoGame.GameType = videoGameUpdateRequest.GameType;
            videoGame.PublisherId = videoGameUpdateRequest.PublisherId;

            int[] originalPlatformIds = videoGame.VideoGamePlatforms.Select(x => x.PlatformId).ToArray();
            int[] newPlatformIds = videoGameUpdateRequest.PlatformIds;

            int[] removedPlatformIds = GetRemoved(originalPlatformIds, newPlatformIds);
            int[] addedPlatformIds = GetAdded(originalPlatformIds, newPlatformIds);

            if (removedPlatformIds.Any())
            {
                IEnumerable<VideoGamePlatform> removedVideoGamePlatforms =
                videoGameDbContext
                .VideoGamePlatforms
                .Where(x => removedPlatformIds.Contains(x.PlatformId) && x.VideoGameId == videoGame.Id);

                foreach (VideoGamePlatform videoGamePlatform in removedVideoGamePlatforms)
                {
                    videoGame.VideoGamePlatforms.Remove(videoGamePlatform);
                }
            }

            if (addedPlatformIds.Any())
            {
                foreach (int addedPlatformId in addedPlatformIds)
                {
                    videoGame.VideoGamePlatforms.Add(new VideoGamePlatform()
                    {
                        VideoGameId = videoGame.Id,
                        PlatformId = addedPlatformId
                    });
                }
            }
            try
            {
                videoGameDbContext.VideoGames.Update(videoGame);
                videoGameDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private int[] GetAdded(int[] originalArray, int[] newArray)
        {
            return newArray.Where(x => !originalArray.Contains(x)).ToArray();
        }

        private int[] GetRemoved(int[] originalArray, int[] newArray)
        {
            return originalArray.Where(x => !newArray.Contains(x)).ToArray();
        }
    }
}
