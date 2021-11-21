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
        public IEnumerable<Platform> GetPlatforms(VideoGameDbContext videoGameDbContext)
        {
            return videoGameDbContext.Platforms;
        }

        public IEnumerable<Publisher> GetPublishers(VideoGameDbContext videoGameDbContext)
        {
            return videoGameDbContext.Publishers;
        }

        public IEnumerable<VideoGameResponse> GetVideoGames(VideoGameDbContext videoGameDbContext)
        {
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
                        });
        }

        public void Update(VideoGameDbContext videoGameDbContext, VideoGameUpdateRequest videoGameUpdateRequest)
        {
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
