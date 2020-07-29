using Microsoft.EntityFrameworkCore.Migrations;

namespace AGAT.LocoDispatcher.Data.Migrations
{
    public partial class addEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    Timestamp = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    TrackerId = table.Column<string>(nullable: true),
                    TrainId = table.Column<string>(nullable: true),
                    CheckPointNumber = table.Column<string>(nullable: true),
                    TrackNumber = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    EmergencyType = table.Column<string>(nullable: true),
                    EmergencyStatus = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
