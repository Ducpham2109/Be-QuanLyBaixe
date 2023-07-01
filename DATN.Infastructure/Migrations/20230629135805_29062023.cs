using Microsoft.EntityFrameworkCore.Migrations;

namespace DATN.Infastructure.Migrations
{
    public partial class _29062023 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntryVehicles_Accounts_Username",
                table: "EntryVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Managements_Parkings_ParkingCode",
                table: "Managements");

            migrationBuilder.DropIndex(
                name: "IX_EntryVehicles_Username",
                table: "EntryVehicles");

            migrationBuilder.AlterColumn<int>(
                name: "ParkingCode",
                table: "Managements",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "AccountUsername",
                table: "EntryVehicles",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EntryVehicles_AccountUsername",
                table: "EntryVehicles",
                column: "AccountUsername");

            migrationBuilder.AddForeignKey(
                name: "FK_EntryVehicles_Accounts_AccountUsername",
                table: "EntryVehicles",
                column: "AccountUsername",
                principalTable: "Accounts",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Managements_Parkings_ParkingCode",
                table: "Managements",
                column: "ParkingCode",
                principalTable: "Parkings",
                principalColumn: "ParkingCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntryVehicles_Accounts_AccountUsername",
                table: "EntryVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Managements_Parkings_ParkingCode",
                table: "Managements");

            migrationBuilder.DropIndex(
                name: "IX_EntryVehicles_AccountUsername",
                table: "EntryVehicles");

            migrationBuilder.DropColumn(
                name: "AccountUsername",
                table: "EntryVehicles");

            migrationBuilder.AlterColumn<int>(
                name: "ParkingCode",
                table: "Managements",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EntryVehicles_Username",
                table: "EntryVehicles",
                column: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_EntryVehicles_Accounts_Username",
                table: "EntryVehicles",
                column: "Username",
                principalTable: "Accounts",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Managements_Parkings_ParkingCode",
                table: "Managements",
                column: "ParkingCode",
                principalTable: "Parkings",
                principalColumn: "ParkingCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
