using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory_Management.Migrations
{
    /// <inheritdoc />
    public partial class MakeNamesNonNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "transactionType",
                table: "Transactions",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "transactionID",
                keyValue: 1,
                column: "transactionDate",
                value: new DateTime(2024, 12, 19, 23, 33, 57, 755, DateTimeKind.Local).AddTicks(1582));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "transactionType",
                keyValue: null,
                column: "transactionType",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "transactionType",
                table: "Transactions",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "transactionID",
                keyValue: 1,
                column: "transactionDate",
                value: new DateTime(2024, 12, 19, 23, 8, 7, 140, DateTimeKind.Local).AddTicks(4694));
        }
    }
}
