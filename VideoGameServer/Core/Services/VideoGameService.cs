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
    }
}
