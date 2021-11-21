using System.Collections.Generic;
using VideoGameServer.Core.Models;

namespace VideoGameServer.Core.Services
{
    public interface IVideoGameService
    {
        IEnumerable<Platform> GetPlatforms(VideoGameDbContext videoGameDbContext);
        IEnumerable<Publisher> GetPublishers(VideoGameDbContext videoGameDbContext);
        IEnumerable<VideoGameResponse> GetVideoGames(VideoGameDbContext videoGameDbContext);
        void Update(VideoGameDbContext videoGameDbContext, VideoGameUpdateRequest videoGameUpdateRequest);
    }
}