using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameServer.Core;
using VideoGameServer.Core.Models;
using VideoGameServer.Core.Services;

namespace VideoGameServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        private readonly IVideoGameService _videoGameService;
        private readonly VideoGameDbContext _videoGameDbContext;
        public VideoGameController(IVideoGameService videoGameService, VideoGameDbContext videoGameDbContext)
        {
            _videoGameService = videoGameService;
            _videoGameDbContext = videoGameDbContext;
        }

        [HttpGet("getPlatforms")]
        public IEnumerable<Platform> GetPlatforms()
        {
            return _videoGameService.GetPlatforms(_videoGameDbContext);
        }

        [HttpGet("getPublishers")]
        public IEnumerable<Publisher> GetPublishers()
        {
            return _videoGameService.GetPublishers(_videoGameDbContext);
        }
    }
}
