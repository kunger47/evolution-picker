using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Evolution.Migrations
{
    public partial class ClassificationsAndTimescalesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Parent_Id = table.Column<int>(nullable: true),
                    Classification_Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Info = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeologicalTimeScales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    LevelName = table.Column<string>(nullable: true),
                    Info = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeologicalTimeScales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Timescales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Parent_Id = table.Column<int>(nullable: true),
                    ScaleID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Info = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timescales", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classifications");

            migrationBuilder.DropTable(
                name: "GeologicalTimeScales");

            migrationBuilder.DropTable(
                name: "Timescales");
        }
    }
}
