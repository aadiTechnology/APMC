using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProject.Entities.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "AppUsers");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "AppUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "IndentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<string>(nullable: true),
                    ProductWeight = table.Column<float>(nullable: false),
                    OrderNo = table.Column<int>(nullable: false),
                    ETATime = table.Column<string>(nullable: true),
                    VehicleNo = table.Column<string>(nullable: true),
                    SupplierNo = table.Column<string>(nullable: true),
                    SupplierName = table.Column<string>(nullable: true),
                    DriverName = table.Column<string>(nullable: true),
                    DriverNo = table.Column<string>(nullable: true),
                    RollId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    AppovedBy = table.Column<int>(nullable: false),
                    IsApprove = table.Column<bool>(nullable: false),
                    IsRejected = table.Column<bool>(nullable: false),
                    RejectReason = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndentDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StallDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StallNo = table.Column<string>(nullable: true),
                    StallName = table.Column<string>(nullable: true),
                    StallRegNo = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    IsAssigned = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StallDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StallProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StallRegistrationId = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StallProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StallRegistration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    StallId = table.Column<int>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    IsRejected = table.Column<bool>(nullable: false),
                    ApproveBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ApprovedDate = table.Column<DateTime>(nullable: false),
                    RejectReason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StallRegistration", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndentDetails");

            migrationBuilder.DropTable(
                name: "StallDetails");

            migrationBuilder.DropTable(
                name: "StallProductCategories");

            migrationBuilder.DropTable(
                name: "StallRegistration");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "AppUsers");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
