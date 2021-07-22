using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce.Persistence.Migrations
{
    public partial class UpdateCartItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256925260,
                columns: new[] { "CreatedDate", "Number", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 7, 11, 14, 31, 20, 623, DateTimeKind.Local).AddTicks(7732), "132704766806278293", new DateTime(2021, 7, 11, 14, 31, 20, 627, DateTimeKind.Local).AddTicks(5335) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256925261,
                columns: new[] { "CreatedDate", "Number", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 7, 11, 14, 31, 20, 628, DateTimeKind.Local).AddTicks(2945), "132704766806282975", new DateTime(2021, 7, 11, 14, 31, 20, 628, DateTimeKind.Local).AddTicks(2970) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256925262,
                columns: new[] { "CreatedDate", "Number", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 7, 11, 14, 31, 20, 628, DateTimeKind.Local).AddTicks(3042), "132704766806283048", new DateTime(2021, 7, 11, 14, 31, 20, 628, DateTimeKind.Local).AddTicks(3045) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256925263,
                columns: new[] { "CreatedDate", "Number", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 7, 11, 14, 31, 20, 628, DateTimeKind.Local).AddTicks(3057), "132704766806283062", new DateTime(2021, 7, 11, 14, 31, 20, 628, DateTimeKind.Local).AddTicks(3060) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256925264,
                columns: new[] { "CreatedDate", "Number", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 7, 11, 14, 31, 20, 628, DateTimeKind.Local).AddTicks(3069), "132704766806283074", new DateTime(2021, 7, 11, 14, 31, 20, 628, DateTimeKind.Local).AddTicks(3071) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256925265,
                columns: new[] { "CreatedDate", "Number", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 7, 11, 14, 31, 20, 628, DateTimeKind.Local).AddTicks(3083), "132704766806283088", new DateTime(2021, 7, 11, 14, 31, 20, 628, DateTimeKind.Local).AddTicks(3086) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256925260,
                columns: new[] { "CreatedDate", "Number", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 7, 11, 14, 25, 11, 57, DateTimeKind.Local).AddTicks(6389), "132704763110590280", new DateTime(2021, 7, 11, 14, 25, 11, 58, DateTimeKind.Local).AddTicks(8211) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256925261,
                columns: new[] { "CreatedDate", "Number", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 7, 11, 14, 25, 11, 59, DateTimeKind.Local).AddTicks(3800), "132704763110593814", new DateTime(2021, 7, 11, 14, 25, 11, 59, DateTimeKind.Local).AddTicks(3811) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256925262,
                columns: new[] { "CreatedDate", "Number", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 7, 11, 14, 25, 11, 59, DateTimeKind.Local).AddTicks(3861), "132704763110593865", new DateTime(2021, 7, 11, 14, 25, 11, 59, DateTimeKind.Local).AddTicks(3863) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256925263,
                columns: new[] { "CreatedDate", "Number", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 7, 11, 14, 25, 11, 59, DateTimeKind.Local).AddTicks(3873), "132704763110593876", new DateTime(2021, 7, 11, 14, 25, 11, 59, DateTimeKind.Local).AddTicks(3874) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256925264,
                columns: new[] { "CreatedDate", "Number", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 7, 11, 14, 25, 11, 59, DateTimeKind.Local).AddTicks(3881), "132704763110593884", new DateTime(2021, 7, 11, 14, 25, 11, 59, DateTimeKind.Local).AddTicks(3882) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256925265,
                columns: new[] { "CreatedDate", "Number", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 7, 11, 14, 25, 11, 59, DateTimeKind.Local).AddTicks(3889), "132704763110593892", new DateTime(2021, 7, 11, 14, 25, 11, 59, DateTimeKind.Local).AddTicks(3890) });
        }
    }
}
