using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AGAT.LocoDispatcher.Data.Migrations
{
    public partial class addLocomotiveShift : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainId",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "LocoId",
                table: "Events",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "LocoShiftsId",
                table: "Events",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LocomotiveShifts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainNumber = table.Column<string>(nullable: true),
                    ESR = table.Column<string>(nullable: true),
                    StartShift = table.Column<DateTime>(nullable: false),
                    EndShift = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocomotiveShifts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_LocoShiftsId",
                table: "Events",
                column: "LocoShiftsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_LocomotiveShifts_LocoShiftsId",
                table: "Events",
                column: "LocoShiftsId",
                principalTable: "LocomotiveShifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_LocomotiveShifts_LocoShiftsId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "LocomotiveShifts");

            migrationBuilder.DropIndex(
                name: "IX_Events_LocoShiftsId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "LocoId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "LocoShiftsId",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "TrainId",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
