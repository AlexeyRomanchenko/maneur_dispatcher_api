using Microsoft.EntityFrameworkCore.Migrations;

namespace AGAT.LocoDispatcher.Data.Migrations
{
    public partial class addValidityMarker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsValid",
                table: "Shifts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsValid",
                table: "Shifts");
        }
    }
}
