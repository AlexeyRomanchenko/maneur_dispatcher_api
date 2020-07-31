using Microsoft.EntityFrameworkCore.Migrations;

namespace AGAT.LocoDispatcher.Data.Migrations
{
    public partial class addShiftsInsteadLocomotives : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_LocomotiveShifts_LocoShiftsId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "Locomotives");

            migrationBuilder.DropIndex(
                name: "IX_Events_LocoShiftsId",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocomotiveShifts",
                table: "LocomotiveShifts");

            migrationBuilder.DropColumn(
                name: "LocoId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "LocoShiftsId",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "LocomotiveShifts",
                newName: "Shifts");

            migrationBuilder.AddColumn<int>(
                name: "ShiftId",
                table: "Events",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Shifts",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shifts",
                table: "Shifts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ShiftId",
                table: "Events",
                column: "ShiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Shifts_ShiftId",
                table: "Events",
                column: "ShiftId",
                principalTable: "Shifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Shifts_ShiftId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_ShiftId",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shifts",
                table: "Shifts");

            migrationBuilder.DropColumn(
                name: "ShiftId",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "Shifts",
                newName: "LocomotiveShifts");

            migrationBuilder.AddColumn<int>(
                name: "LocoId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "LocoShiftsId",
                table: "Events",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "LocomotiveShifts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocomotiveShifts",
                table: "LocomotiveShifts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Locomotives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Angle = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locomotives", x => x.Id);
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
    }
}
