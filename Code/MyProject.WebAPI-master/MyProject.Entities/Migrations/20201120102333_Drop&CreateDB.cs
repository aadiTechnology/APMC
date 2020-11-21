using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProject.Entities.Migrations
{
    public partial class DropCreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    SurName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndentId = table.Column<int>(nullable: false),
                    OrderNo = table.Column<int>(nullable: false),
                    ETADate = table.Column<string>(nullable: true),
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
                name: "IndentProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndentId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductName = table.Column<string>(nullable: true),
                    ProductQuantity = table.Column<string>(nullable: true),
                    UnitId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndentProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unit = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "IndentDetails");

            migrationBuilder.DropTable(
                name: "IndentProducts");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "StallDetails");

            migrationBuilder.DropTable(
                name: "StallProductCategories");

            migrationBuilder.DropTable(
                name: "StallRegistration");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
