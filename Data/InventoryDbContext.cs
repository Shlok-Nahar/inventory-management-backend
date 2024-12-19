using Microsoft.EntityFrameworkCore;

namespace InventoryManagement
{
    public class InventoryDbContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; } = null!;
        public DbSet<SupplierEntity> Suppliers { get; set; } = null!;
        public DbSet<CustomerEntity> Customers { get; set; } = null!;
        public DbSet<TransactionEntity> Transactions { get; set; } = null!;

        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring the "Transaction Type" enum to be stored as a string in the database
            modelBuilder.Entity<TransactionEntity>()
                .Property(t => t.transactionType)
                .HasConversion<string>();  // Storing the enum as a string in the database

            // Configuring the relationship between ProductEntity and SupplierEntity
            modelBuilder.Entity<ProductEntity>()
                .HasOne(p => p.supplierEntity)  // A Product has one Supplier
                .WithMany(s => s.productEntities)  // A Supplier has many Products
                .HasForeignKey(p => p.supplierID)
                .OnDelete(DeleteBehavior.SetNull);  // Optional: Configure cascading behavior

            // Configuring the relationship between TransactionEntity and ProductEntity
            modelBuilder.Entity<TransactionEntity>()
                .HasOne(t => t.productEntity)  // A Transaction has one Product
                .WithMany(p => p.transactionEntities)  // A Product has many Transactions
                .HasForeignKey(t => t.productID)
                .OnDelete(DeleteBehavior.Restrict);  // Optional: Configure cascading behavior

            // Configuring the relationship between ProductEntity and CustomerEntity
            modelBuilder.Entity<ProductEntity>()
                .HasOne(p => p.customerEntity)  // A Product has one Customer
                .WithMany(c => c.productEntities)  // A Customer has many Products
                .HasForeignKey(p => p.customerID)
                .OnDelete(DeleteBehavior.SetNull);  // Optional: Configure cascading behavior

            // Setting up primary keys for each entity
            modelBuilder.Entity<CustomerEntity>().HasKey(c => c.customerID);
            modelBuilder.Entity<SupplierEntity>().HasKey(s => s.supplierID);
            modelBuilder.Entity<ProductEntity>().HasKey(p => p.productID);
            modelBuilder.Entity<TransactionEntity>().HasKey(t => t.transactionID);

            // Create fake data for testing

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductEntity>().HasData(
                new ProductEntity { productID = 1, productName = "Product A", price = 10.99f, stock = 100, supplierID = 1, customerID = null },
                new ProductEntity { productID = 2, productName = "Product B", price = 20.49f, stock = 50, supplierID = null, customerID = null },
                new ProductEntity { productID = 3, productName = "Product C", price = 15.99f, stock = 75, supplierID = null, customerID = 2 }
            );

            modelBuilder.Entity<CustomerEntity>().HasData(
                new CustomerEntity { customerID = 1, customerName = "Customer A", contactInfo = "123-456-7890" },
                new CustomerEntity { customerID = 2, customerName = "Customer B", contactInfo = "" }
            );
            modelBuilder.Entity<SupplierEntity>().HasData(
                new SupplierEntity { supplierID = 1, supplierName = "Supplier A", contactInfo = "987-654-3210" },
                new SupplierEntity { supplierID = 2, supplierName = "Supplier B", contactInfo = "" }
            );
            modelBuilder.Entity<TransactionEntity>().HasData(
                new TransactionEntity { transactionID = 1, productID = 1, transactionType = "Purchase", quantity = 5, transactionDate = DateTime.Now },
                new TransactionEntity { transactionID = 2, productID = 2, transactionType = "Sale", quantity = 2, transactionDate = null }
            );
        }
    }
}
