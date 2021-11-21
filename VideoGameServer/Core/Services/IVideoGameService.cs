using System.Collections.Generic;
using VideoGameServer.Core.Models;

namespace VideoGameServer.Core.Services
{
    public interface IVideoGameService
    {
        IEnumerable<Platform> GetPlatforms(VideoGameDbContext videoGameDbContext);
    }
}