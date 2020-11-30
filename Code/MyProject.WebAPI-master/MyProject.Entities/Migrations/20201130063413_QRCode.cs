using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProject.Entities.Migrations
{
    public partial class QRCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsScanned",
                table: "IndentDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "QrId",
                table: "IndentDetails",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ChargesTypeMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoParkingCharges = table.Column<decimal>(nullable: false),
                    ExtraTimeCharges = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargesTypeMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GlobalConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalConfigurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParkingCharges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndentId = table.Column<string>(nullable: true),
                    VehicleTypeId = table.Column<string>(nullable: true),
                    VehicleNumber = table.Column<string>(nullable: true),
                    EntryFee = table.Column<string>(nullable: true),
                    ChargesTypeId = table.Column<int>(nullable: false),
                    InTime = table.Column<DateTime>(nullable: false),
                    OutTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingCharges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypeMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypeMaster", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChargesTypeMaster");

            migrationBuilder.DropTable(
                name: "GlobalConfigurations");

            migrationBuilder.DropTable(
                name: "ParkingCharges");

            migrationBuilder.DropTable(
                name: "VehicleTypeMaster");

            migrationBuilder.DropColumn(
                name: "IsScanned",
                table: "IndentDetails");

            migrationBuilder.DropColumn(
                name: "QrId",
                table: "IndentDetails");
        }
    }
}
