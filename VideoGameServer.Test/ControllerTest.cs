using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using VideoGameServer.Controllers;
using VideoGameServer.Core;
using VideoGameServer.Core.Models;
using VideoGameServer.Core.Services;

namespace VideoGameServer.Test
{
    [TestClass]
    public class ControllerTest
    {
        private readonly Mock<IVideoGameService> _videoGameService = new Mock<IVideoGameService>();
        private readonly VideoGameDbContext _videoGameDbContext; 
        private readonly VideoGameController _videoGameController;

        private readonly Platform[] _platforms = new Platform[2]
        {
            new Platform()
            {
                Id = 1,
                Name = "test1"
            },
            new Platform()
            {
                Id = 2,
                Name = "test2"
            }
        };
        private readonly Publisher[] _publishers = new Publisher[2]
        {
            new Publisher()
            {
                Id = 1,
                Name = "test1"
            },
            new Publisher()
            {
                Id = 2,
                Name = "test2"
            }
        };
        private readonly VideoGameResponse[] _videoGameResponses = new VideoGameResponse[2]
        {
            new VideoGameResponse()
            {
                Id = 1,
                Name = "test1",
                Description = "description1",
                GameType = GameType.Multiple,
                Publisher = new Publisher()
                {
                    Id = 1,
                    Name = "test1"
                },
                Platforms = new Platform[2] 
                {
                    new Platform()
                    {
                        Id = 1,
                        Name = "test1"
                    },
                    new Platform()
                    {
                        Id = 2,
                        Name = "test2"
                    } 
                }
            },
            new VideoGameResponse()
            {
                Id = 2,
                Name = "test2",
                Description = "description2",
                GameType = GameType.Single,
                Publisher = new Publisher()
                {
                    Id = 1,
                    Name = "test1"
                },
                Platforms = new Platform[2]
                {
                    new Platform()
                    {
                        Id = 1,
                        Name = "test1"
                    },
                    new Platform()
                    {
                        Id = 2,
                        Name = "test2"
                    }
                }
            }
        };

        public ControllerTest()
        {
            var options = new DbContextOptionsBuilder<VideoGameDbContext>()
                .UseSqlServer()
                .Options;
            _videoGameDbContext = new VideoGameDbContext(options);
            _videoGameController = new VideoGameController(_videoGameService.Object, _videoGameDbContext);
        }

        [TestMethod]
        public void GetPlatformsTest()
        {
            _videoGameService.Setup(x => x.GetPlatforms(_videoGameDbContext)).Returns(_platforms);
            Platform[] platforms = _videoGameController.GetPlatforms().ToArray();
            CollectionAssert.AreEqual(_platforms, platforms);
        }

        [TestMethod]
        public void GetPublishersTest()
        {
            _videoGameService.Setup(x => x.GetPublishers(_videoGameDbContext)).Returns(_publishers);
            Publisher[] publishers = _videoGameController.GetPublishers().ToArray();
            CollectionAssert.AreEqual(_publishers, publishers);
        }

        [TestMethod]
        public void GetVideoGamesTest()
        {
            _videoGameService.Setup(x => x.GetVideoGames(_videoGameDbContext)).Returns(_videoGameResponses);
            VideoGameResponse[] videoGameResponses = _videoGameController.GetVideoGames().ToArray();
            CollectionAssert.AreEqual(_videoGameResponses, videoGameResponses);
        }
    }
}
