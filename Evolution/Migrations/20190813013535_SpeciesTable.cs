using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Evolution.Migrations
{
    public partial class SpeciesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TheSpecies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Ancestor_Id = table.Column<int>(nullable: false),
                    Classification_Id = table.Column<int>(nullable: true),
                    Timespan_Id = table.Column<int>(nullable: true),
                    Pressure_Id = table.Column<int>(nullable: false),
                    SpeciesName = table.Column<string>(nullable: true),
                    CommonName = table.Column<string>(nullable: true),
                    Adaption = table.Column<string>(nullable: true),
                    Info = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheSpecies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TheSpecies");
        }
    }
}
