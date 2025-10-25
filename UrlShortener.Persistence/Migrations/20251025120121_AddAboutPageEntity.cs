using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrlShortener.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAboutPageEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutPage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutPage", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AboutPage",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate" },
                values: new object[] { new Guid("cf140332-bddc-424e-8550-fd65bee52e78"), "Our URL Shortener allows you to quickly generate a short and easy-to-share link for any long URL. The shortening process works using a simple algorithm implemented in our CodeService. 1) Character Set: The service uses a set of 62 characters, including lowercase letters (a-z), uppercase letters (A-Z), and digits (0-9). 2) Random Generation: For each URL, the service generates a random string of a default length of 6 characters. This string serves as the unique short code. 3) Short URL Creation: The generated short code is appended to our domain, producing a short link like https://localhost:7018/shortUrl/s/dvYUXJ. 4) Redirection: When someone visits the short URL, our service looks up the original URL associated with the code and redirects the user automatically. This approach ensures that every short URL is unique and can be quickly generated without collisions in most cases. Admins can manage all short URLs and their associated original links.", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutPage");
        }
    }
}
