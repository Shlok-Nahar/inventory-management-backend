using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory_Management.Migrations
{
    /// <inheritdoc />
    public partial class RedoTransactionLogic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "customerID",
                table: "Transactions",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddColumn<int>(
                name: "supplierID",
                table: "Transactions",
                type: "int",
                nullable: true);

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
                columns: new[] { "customerID", "customerName", "productName", "supplierID", "supplierName", "transactionDate" },
                values: new object[] { null, null, null, null, null, new DateTime(2024, 12, 26, 20, 57, 31, 371, DateTimeKind.Local).AddTicks(5206) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "transactionID",
                keyValue: 2,
                columns: new[] { "customerID", "customerName", "productName", "supplierID", "supplierName" },
                values: new object[] { null, null, null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_customerID",
                table: "Transactions",
                column: "customerID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_supplierID",
                table: "Transactions",
                column: "supplierID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Customers_customerID",
                table: "Transactions",
                column: "customerID",
                principalTable: "Customers",
                principalColumn: "customerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Suppliers_supplierID",
                table: "Transactions",
                column: "supplierID",
                principalTable: "Suppliers",
                principalColumn: "supplierID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Customers_customerID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Suppliers_supplierID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_customerID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_supplierID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "customerID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "customerName",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "productName",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "supplierID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "supplierName",
                table: "Transactions");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "transactionID",
                keyValue: 1,
                column: "transactionDate",
                value: new DateTime(2024, 12, 19, 23, 33, 57, 755, DateTimeKind.Local).AddTicks(1582));
        }
    }
}
