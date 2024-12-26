using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory_Management.Migrations
{
    /// <inheritdoc />
    public partial class RemoveNamesFromTransactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "customerName",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "productName",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "supplierName",
                table: "Transactions");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "transactionID",
                keyValue: 1,
                column: "transactionDate",
                value: new DateTime(2024, 12, 26, 21, 8, 26, 173, DateTimeKind.Local).AddTicks(8755));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "customerName",
                table: "Transactions",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "productName",
                table: "Transactions",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "supplierName",
                table: "Transactions",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "transactionID",
                keyValue: 1,
                columns: new[] { "customerName", "productName", "supplierName", "transactionDate" },
                values: new object[] { null, null, null, new DateTime(2024, 12, 26, 20, 57, 31, 371, DateTimeKind.Local).AddTicks(5206) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "transactionID",
                keyValue: 2,
                columns: new[] { "customerName", "productName", "supplierName" },
                values: new object[] { null, null, null });
        }
    }
}
