using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProject.Entities.Migrations
{
    public partial class APMC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "IndentProducts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "IndentDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ETADate",
                table: "IndentDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IndentId",
                table: "IndentDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "IndentDetails",
                nullable: true);

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
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "IndentProducts");

            migrationBuilder.DropColumn(
                name: "ETADate",
                table: "IndentDetails");

            migrationBuilder.DropColumn(
                name: "IndentId",
                table: "IndentDetails");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "IndentDetails");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "IndentDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
