using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Batuhan.WebApi.Migrations
{
    public partial class mssqlMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 26, 1, 6, 9, 342, DateTimeKind.Local).AddTicks(6540));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 17, 1, 6, 9, 342, DateTimeKind.Local).AddTicks(7426));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 7, 24, 1, 6, 9, 342, DateTimeKind.Local).AddTicks(7436));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 26, 1, 5, 6, 748, DateTimeKind.Local).AddTicks(5890));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 17, 1, 5, 6, 748, DateTimeKind.Local).AddTicks(6620));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 7, 24, 1, 5, 6, 748, DateTimeKind.Local).AddTicks(6627));
        }
    }
}
