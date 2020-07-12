using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce_MVC_Core.Migrations
{
    public partial class addeditEntityColorsmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                table: "ProductLikes",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 9, 19, 48, 31, 408, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 9, 19, 28, 50, 39, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                table: "OrderStatus",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 9, 19, 48, 31, 425, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 9, 19, 28, 50, 55, DateTimeKind.Local));

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Colors",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                table: "ProductLikes",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 9, 19, 28, 50, 39, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 9, 19, 48, 31, 408, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                table: "OrderStatus",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 9, 19, 28, 50, 55, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 9, 19, 48, 31, 425, DateTimeKind.Local));

            migrationBuilder.AlterColumn<int>(
                name: "Color",
                table: "Colors",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
