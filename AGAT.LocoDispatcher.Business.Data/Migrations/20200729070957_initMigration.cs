using Microsoft.EntityFrameworkCore.Migrations;

namespace AGAT.LocoDispatcher.Data.Migrations
{
    public partial class initMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carriages");

            migrationBuilder.DropTable(
                name: "Coords");

            migrationBuilder.DropTable(
                name: "Locomotives");

            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropTable(
                name: "RoutePlates");

            migrationBuilder.DropTable(
                name: "Rails");

            migrationBuilder.DropTable(
                name: "Parks");

            migrationBuilder.DropTable(
                name: "Stations");
        }
    }
}
