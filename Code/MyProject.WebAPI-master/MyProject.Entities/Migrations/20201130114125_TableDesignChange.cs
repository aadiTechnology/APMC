using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProject.Entities.Migrations
{
    public partial class TableDesignChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChargesTypeId",
                table: "ParkingCharges");

            migrationBuilder.AddColumn<string>(
                name: "EntryFee",
                table: "VehicleTypeMaster",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExtraTime",
                table: "VehicleTypeMaster",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ExtraTimeFee",
                table: "VehicleTypeMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoParkingFee",
                table: "VehicleTypeMaster",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExtraTime",
                table: "ParkingCharges",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ExtraTimeFee",
                table: "ParkingCharges",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoParkingFee",
                table: "ParkingCharges",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntryFee",
                table: "VehicleTypeMaster");

            migrationBuilder.DropColumn(
                name: "ExtraTime",
                table: "VehicleTypeMaster");

            migrationBuilder.DropColumn(
                name: "ExtraTimeFee",
                table: "VehicleTypeMaster");

            migrationBuilder.DropColumn(
                name: "NoParkingFee",
                table: "VehicleTypeMaster");

            migrationBuilder.DropColumn(
                name: "ExtraTime",
                table: "ParkingCharges");

            migrationBuilder.DropColumn(
                name: "ExtraTimeFee",
                table: "ParkingCharges");

            migrationBuilder.DropColumn(
                name: "NoParkingFee",
                table: "ParkingCharges");

            migrationBuilder.AddColumn<int>(
                name: "ChargesTypeId",
                table: "ParkingCharges",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
