using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory_Management.Migrations
{
    /// <inheritdoc />
    public partial class RenameNameToProductName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Customers_CustomerID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_SupplierID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Products_ProductID",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Transactions",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Transactions",
                newName: "productID");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Transactions",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "TransactionID",
                table: "Transactions",
                newName: "transactionID");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Transactions",
                newName: "transactionType");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_ProductID",
                table: "Transactions",
                newName: "IX_Transactions_productID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Suppliers",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "ContactInfo",
                table: "Suppliers",
                newName: "contactInfo");

            migrationBuilder.RenameColumn(
                name: "SupplierID",
                table: "Suppliers",
                newName: "supplierID");

            migrationBuilder.RenameColumn(
                name: "SupplierID",
                table: "Products",
                newName: "supplierID");

            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "Products",
                newName: "stock");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Products",
                newName: "customerID");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Products",
                newName: "productID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "productName");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SupplierID",
                table: "Products",
                newName: "IX_Products_supplierID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CustomerID",
                table: "Products",
                newName: "IX_Products_customerID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Customers",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "ContactInfo",
                table: "Customers",
                newName: "contactInfo");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Customers",
                newName: "customerID");

            migrationBuilder.AlterColumn<int>(
                name: "stock",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Customers_customerID",
                table: "Products",
                column: "customerID",
                principalTable: "Customers",
                principalColumn: "customerID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Suppliers_supplierID",
                table: "Products",
                column: "supplierID",
                principalTable: "Suppliers",
                principalColumn: "supplierID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Products_productID",
                table: "Transactions",
                column: "productID",
                principalTable: "Products",
                principalColumn: "productID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Customers_customerID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_supplierID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Products_productID",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "Transactions",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "productID",
                table: "Transactions",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Transactions",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "transactionID",
                table: "Transactions",
                newName: "TransactionID");

            migrationBuilder.RenameColumn(
                name: "transactionType",
                table: "Transactions",
                newName: "Type");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_productID",
                table: "Transactions",
                newName: "IX_Transactions_ProductID");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Suppliers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "contactInfo",
                table: "Suppliers",
                newName: "ContactInfo");

            migrationBuilder.RenameColumn(
                name: "supplierID",
                table: "Suppliers",
                newName: "SupplierID");

            migrationBuilder.RenameColumn(
                name: "supplierID",
                table: "Products",
                newName: "SupplierID");

            migrationBuilder.RenameColumn(
                name: "stock",
                table: "Products",
                newName: "Stock");

            migrationBuilder.RenameColumn(
                name: "customerID",
                table: "Products",
                newName: "CustomerID");

            migrationBuilder.RenameColumn(
                name: "productID",
                table: "Products",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "productName",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Products_supplierID",
                table: "Products",
                newName: "IX_Products_SupplierID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_customerID",
                table: "Products",
                newName: "IX_Products_CustomerID");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Customers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "contactInfo",
                table: "Customers",
                newName: "ContactInfo");

            migrationBuilder.RenameColumn(
                name: "customerID",
                table: "Customers",
                newName: "CustomerID");

            migrationBuilder.AlterColumn<int>(
                name: "Stock",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Customers_CustomerID",
                table: "Products",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Suppliers_SupplierID",
                table: "Products",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "SupplierID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Products_ProductID",
                table: "Transactions",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
