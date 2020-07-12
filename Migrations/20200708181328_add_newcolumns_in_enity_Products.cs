using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce_MVC_Core.Migrations
{
    public partial class add_newcolumns_in_enity_Products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                table: "ProductLikes",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 19, 13, 28, 178, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 3, 22, 38, 13, 643, DateTimeKind.Local));

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Product",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "Product",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath2",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath3",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                table: "OrderStatus",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 8, 19, 13, 28, 196, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 3, 22, 38, 13, 664, DateTimeKind.Local));

            migrationBuilder.CreateTable(
                name: "ProductColors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductColors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductColors_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductColors_ProductId",
                table: "ProductColors",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductColors");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ImagePath2",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ImagePath3",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Product");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                table: "ProductLikes",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 3, 22, 38, 13, 643, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 8, 19, 13, 28, 178, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                table: "OrderStatus",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 3, 22, 38, 13, 664, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 8, 19, 13, 28, 196, DateTimeKind.Local));
        }
    }
}
