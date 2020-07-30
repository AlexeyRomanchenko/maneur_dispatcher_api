using Microsoft.EntityFrameworkCore.Migrations;

namespace AGAT.LocoDispatcher.Data.Migrations
{
    public partial class addStartMoveEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Direction",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DirectionParty",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direction",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "DirectionParty",
                table: "Events");
        }
    }
}
