using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Inventory_Management.Migrations
{
    /// <inheritdoc />
    public partial class CreateTestEntries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Suppliers",
                newName: "supplierName");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Customers",
                newName: "customerName");

            migrationBuilder.AddColumn<DateTime>(
                name: "transactionDate",
                table: "Transactions",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "stock",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "customerID", "contactInfo", "customerName" },
                values: new object[,]
                {
                    { 1, "123-456-7890", "Customer A" },
                    { 2, "", "Customer B" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "productID", "customerID", "price", "productName", "stock", "supplierID" },
                values: new object[] { 2, null, 20.49f, "Product B", 50, null });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "supplierID", "contactInfo", "supplierName" },
                values: new object[,]
                {
                    { 1, "987-654-3210", "Supplier A" },
                    { 2, "", "Supplier B" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "productID", "customerID", "price", "productName", "stock", "supplierID" },
                values: new object[,]
                {
                    { 1, null, 10.99f, "Product A", 100, 1 },
                    { 3, 2, 15.99f, "Product C", 75, null }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "transactionID", "productID", "quantity", "transactionDate", "transactionType" },
                values: new object[,]
                {
                    { 2, 2, 2, null, "Sale" },
                    { 1, 1, 5, new DateTime(2024, 12, 19, 23, 8, 7, 140, DateTimeKind.Local).AddTicks(4694), "Purchase" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "customerID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "productID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "supplierID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "transactionID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "transactionID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "customerID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "productID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "productID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "supplierID",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "transactionDate",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "supplierName",
                table: "Suppliers",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "customerName",
                table: "Customers",
                newName: "name");

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "Transactions",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "stock",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
