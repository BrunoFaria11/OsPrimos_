using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce_MVC_Core.Migrations
{
    public partial class addeditEntitySizemig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductColors");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "ProductStock");

            migrationBuilder.RenameColumn(
                name: "OutQuantity",
                table: "ProductStock",
                newName: "SizeId");

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "ProductStock",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductStock",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                table: "ProductLikes",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 9, 22, 41, 5, 463, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 9, 19, 48, 31, 408, DateTimeKind.Local));

            migrationBuilder.AddColumn<double>(
                name: "FinalPrice",
                table: "Product",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "HaveStock",
                table: "Product",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                table: "OrderStatus",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 9, 22, 41, 5, 488, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 9, 19, 48, 31, 425, DateTimeKind.Local));

            migrationBuilder.CreateTable(
                name: "ProductSize",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Size = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSize", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductStock_ColorId",
                table: "ProductStock",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStock_ProductId",
                table: "ProductStock",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStock_SizeId",
                table: "ProductStock",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStock_Colors_ColorId",
                table: "ProductStock",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStock_Product_ProductId",
                table: "ProductStock",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStock_ProductSize_SizeId",
                table: "ProductStock",
                column: "SizeId",
                principalTable: "ProductSize",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductStock_Colors_ColorId",
                table: "ProductStock");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductStock_Product_ProductId",
                table: "ProductStock");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductStock_ProductSize_SizeId",
                table: "ProductStock");

            migrationBuilder.DropTable(
                name: "ProductSize");

            migrationBuilder.DropIndex(
                name: "IX_ProductStock_ColorId",
                table: "ProductStock");

            migrationBuilder.DropIndex(
                name: "IX_ProductStock_ProductId",
                table: "ProductStock");

            migrationBuilder.DropIndex(
                name: "IX_ProductStock_SizeId",
                table: "ProductStock");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "ProductStock");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductStock");

            migrationBuilder.DropColumn(
                name: "FinalPrice",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "HaveStock",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "SizeId",
                table: "ProductStock",
                newName: "OutQuantity");

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "ProductStock",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                table: "ProductLikes",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 9, 19, 48, 31, 408, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 9, 22, 41, 5, 463, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                table: "OrderStatus",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 9, 19, 48, 31, 425, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 9, 22, 41, 5, 488, DateTimeKind.Local));

            migrationBuilder.CreateTable(
                name: "ProductColors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ColorId = table.Column<int>(nullable: false),
                    ColorsId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductColors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductColors_Colors_ColorsId",
                        column: x => x.ColorsId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductColors_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductColors_ColorsId",
                table: "ProductColors",
                column: "ColorsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColors_ProductId",
                table: "ProductColors",
                column: "ProductId");
        }
    }
}
