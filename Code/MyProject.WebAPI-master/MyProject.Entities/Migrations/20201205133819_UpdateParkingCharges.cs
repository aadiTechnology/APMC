using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProject.Entities.Migrations
{
    public partial class UpdateParkingCharges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ExtraTimeFee",
                table: "VehicleTypeMaster",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "ExtraTimeFee",
                table: "ParkingCharges",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ExtraTimeFee",
                table: "VehicleTypeMaster",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ExtraTimeFee",
                table: "ParkingCharges",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);
        }
    }
}
