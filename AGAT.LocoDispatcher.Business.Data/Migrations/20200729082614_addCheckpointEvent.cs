using Microsoft.EntityFrameworkCore.Migrations;

namespace AGAT.LocoDispatcher.Data.Migrations
{
    public partial class addCheckpointEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DirectionParty",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "Speed",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DirectionParity",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Speed",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "DirectionParity",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "DirectionParty",
                table: "Events",
                type: "int",
                nullable: true);
        }
    }
}
