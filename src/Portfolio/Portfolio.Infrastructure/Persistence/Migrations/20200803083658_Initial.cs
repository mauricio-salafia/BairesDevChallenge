using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Infrastructure.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CountryName = table.Column<string>(maxLength: 255, nullable: false),
                    Enable = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    IndustryId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IndustryName = table.Column<string>(maxLength: 255, nullable: false),
                    Enable = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industries", x => x.IndustryId);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ProfileId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(maxLength: 255, nullable: false),
                    LastName = table.Column<string>(maxLength: 255, nullable: true),
                    CurrentRole = table.Column<string>(maxLength: 255, nullable: true),
                    NumberOfRecommendations = table.Column<int>(nullable: true),
                    NumberOfConnections = table.Column<int>(nullable: true),
                    CountryId = table.Column<long>(nullable: false),
                    IndustryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.ProfileId);
                    table.ForeignKey(
                        name: "FK_Profiles_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profiles_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "IndustryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_CountryId",
                table: "Profiles",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_IndustryId",
                table: "Profiles",
                column: "IndustryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Industries");
        }
    }
}
