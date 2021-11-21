using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameServer.Core.Models;

namespace VideoGameServer.Core
{
    public class VideoGameDbContext : DbContext
    {
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<VideoGamePlatform> VideoGamePlatforms { get; set; }

        public VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publisher>().ToTable("Publisher");
            modelBuilder.Entity<Platform>().ToTable("Platform");
            modelBuilder.Entity<VideoGame>().ToTable("VideoGame");
            modelBuilder.Entity<VideoGamePlatform>()
                .ToTable("VideoGamePlatform")
                .HasKey(vp => new { vp.PlatformId, vp.VideoGameId });

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher
                {
                    Id = 1,
                    Name = "PM Studios",
                },
                new Publisher
                {
                    Id = 2,
                    Name = "Milestone",
                },
                new Publisher
                {
                    Id = 3,
                    Name = "Bloober Team SA",
                }
                );

            modelBuilder.Entity<Platform>().HasData(
                new Platform
                {
                    Id = 1,
                    Name = "PS4",
                },
                new Platform
                {
                    Id = 2,
                    Name = "XBO",
                },
                new Platform
                {
                    Id = 3,
                    Name = "PS5",
                },
                new Platform
                {
                    Id = 4,
                    Name = "XSX",
                },
                new Platform
                {
                    Id = 5,
                    Name = "Win",
                }
                );

            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame
                {
                    Id = 1,
                    Name = "Iris.Fall",
                    Description = "A puzzle adventure game featuring striking visuals and a spellbinding theme of \"light and shadow\".",
                    GameType = GameType.Online,
                    PublisherId = 1
                },
                new VideoGame
                {
                    Id = 2,
                    Name = "Ride 4",
                    Description = "A motorcycle racing video game.",
                    GameType = GameType.Multiple,
                    PublisherId = 2
                },
                new VideoGame
                {
                    Id = 3,
                    Name = "The Medium",
                    Description = "A psychological horror video game.",
                    GameType = GameType.Single,
                    PublisherId = 3
                }
                );

            modelBuilder.Entity<VideoGamePlatform>().HasData(
                new VideoGamePlatform
                {
                    PlatformId = 1,
                    VideoGameId = 1
                },
                new VideoGamePlatform
                {
                    PlatformId = 2,
                    VideoGameId = 1
                },
                new VideoGamePlatform
                {
                    PlatformId = 3,
                    VideoGameId = 2
                },
                new VideoGamePlatform
                {
                    PlatformId = 4,
                    VideoGameId = 2
                },
                new VideoGamePlatform
                {
                    PlatformId = 5,
                    VideoGameId = 3
                },
                new VideoGamePlatform
                {
                    PlatformId = 4,
                    VideoGameId = 3
                }
                );
        }
    }
}
