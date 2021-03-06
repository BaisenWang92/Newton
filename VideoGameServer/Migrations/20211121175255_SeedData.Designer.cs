// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VideoGameServer.Core;

namespace VideoGameServer.Migrations
{
    [DbContext(typeof(VideoGameDbContext))]
    [Migration("20211121175255_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VideoGameServer.Core.Models.Platform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Platform");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "PS4"
                        },
                        new
                        {
                            Id = 2,
                            Name = "XBO"
                        },
                        new
                        {
                            Id = 3,
                            Name = "PS5"
                        },
                        new
                        {
                            Id = 4,
                            Name = "XSX"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Win"
                        });
                });

            modelBuilder.Entity("VideoGameServer.Core.Models.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Publisher");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "PM Studios"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Milestone"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Bloober Team SA"
                        });
                });

            modelBuilder.Entity("VideoGameServer.Core.Models.VideoGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GameType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PublisherId");

                    b.ToTable("VideoGame");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A puzzle adventure game featuring striking visuals and a spellbinding theme of \"light and shadow\".",
                            GameType = 2,
                            Name = "Iris.Fall",
                            PublisherId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "A motorcycle racing video game.",
                            GameType = 1,
                            Name = "Ride 4",
                            PublisherId = 2
                        },
                        new
                        {
                            Id = 3,
                            Description = "A psychological horror video game.",
                            GameType = 0,
                            Name = "The Medium",
                            PublisherId = 3
                        });
                });

            modelBuilder.Entity("VideoGameServer.Core.Models.VideoGamePlatform", b =>
                {
                    b.Property<int>("PlatformId")
                        .HasColumnType("int");

                    b.Property<int>("VideoGameId")
                        .HasColumnType("int");

                    b.HasKey("PlatformId", "VideoGameId");

                    b.HasIndex("VideoGameId");

                    b.ToTable("VideoGamePlatform");

                    b.HasData(
                        new
                        {
                            PlatformId = 1,
                            VideoGameId = 1
                        },
                        new
                        {
                            PlatformId = 2,
                            VideoGameId = 1
                        },
                        new
                        {
                            PlatformId = 3,
                            VideoGameId = 2
                        },
                        new
                        {
                            PlatformId = 4,
                            VideoGameId = 2
                        },
                        new
                        {
                            PlatformId = 5,
                            VideoGameId = 3
                        },
                        new
                        {
                            PlatformId = 4,
                            VideoGameId = 3
                        });
                });

            modelBuilder.Entity("VideoGameServer.Core.Models.VideoGame", b =>
                {
                    b.HasOne("VideoGameServer.Core.Models.Publisher", "Publisher")
                        .WithMany("VideoGames")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("VideoGameServer.Core.Models.VideoGamePlatform", b =>
                {
                    b.HasOne("VideoGameServer.Core.Models.Platform", "Platform")
                        .WithMany("VideoGamePlatforms")
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VideoGameServer.Core.Models.VideoGame", "VideoGame")
                        .WithMany("VideoGamePlatforms")
                        .HasForeignKey("VideoGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Platform");

                    b.Navigation("VideoGame");
                });

            modelBuilder.Entity("VideoGameServer.Core.Models.Platform", b =>
                {
                    b.Navigation("VideoGamePlatforms");
                });

            modelBuilder.Entity("VideoGameServer.Core.Models.Publisher", b =>
                {
                    b.Navigation("VideoGames");
                });

            modelBuilder.Entity("VideoGameServer.Core.Models.VideoGame", b =>
                {
                    b.Navigation("VideoGamePlatforms");
                });
#pragma warning restore 612, 618
        }
    }
}
