using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoGameServer.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Platform",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "PS4" },
                    { 2, "XBO" },
                    { 3, "PS5" },
                    { 4, "XSX" },
                    { 5, "Win" }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "PM Studios" },
                    { 2, "Milestone" },
                    { 3, "Bloober Team SA" }
                });

            migrationBuilder.InsertData(
                table: "VideoGame",
                columns: new[] { "Id", "Description", "GameType", "Name", "PublisherId" },
                values: new object[] { 1, "A puzzle adventure game featuring striking visuals and a spellbinding theme of \"light and shadow\".", 2, "Iris.Fall", 1 });

            migrationBuilder.InsertData(
                table: "VideoGame",
                columns: new[] { "Id", "Description", "GameType", "Name", "PublisherId" },
                values: new object[] { 2, "A motorcycle racing video game.", 1, "Ride 4", 2 });

            migrationBuilder.InsertData(
                table: "VideoGame",
                columns: new[] { "Id", "Description", "GameType", "Name", "PublisherId" },
                values: new object[] { 3, "A psychological horror video game.", 0, "The Medium", 3 });

            migrationBuilder.InsertData(
                table: "VideoGamePlatform",
                columns: new[] { "PlatformId", "VideoGameId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 2 },
                    { 5, 3 },
                    { 4, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VideoGamePlatform",
                keyColumns: new[] { "PlatformId", "VideoGameId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "VideoGamePlatform",
                keyColumns: new[] { "PlatformId", "VideoGameId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "VideoGamePlatform",
                keyColumns: new[] { "PlatformId", "VideoGameId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "VideoGamePlatform",
                keyColumns: new[] { "PlatformId", "VideoGameId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "VideoGamePlatform",
                keyColumns: new[] { "PlatformId", "VideoGameId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "VideoGamePlatform",
                keyColumns: new[] { "PlatformId", "VideoGameId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "Platform",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Platform",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Platform",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Platform",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Platform",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VideoGame",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VideoGame",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VideoGame",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
