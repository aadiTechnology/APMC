using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProject.Entities.Migrations
{
    public partial class AddedNewFileds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FineCharges",
                table: "ParkingCharges",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedById",
                table: "ParkingCharges",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ParkingCharges",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FineCharges",
                table: "ParkingCharges");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "ParkingCharges");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ParkingCharges");
        }
    }
}
