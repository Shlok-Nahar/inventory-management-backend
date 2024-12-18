using Microsoft.EntityFrameworkCore;

namespace InventoryManagement
{
    public class InventoryDbContext : DbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Transactions> Transactions { get; set; }

        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                // Configuring the "Transaction Type" enum to be stored as a string in the database
                modelBuilder.Entity<Transactions>()
                    .Property(t => t.Type)
                    .HasConversion<string>();  // Storing the enum as a string in the database

                // Configuring the relationship between Products and Suppliers
                modelBuilder.Entity<Products>()
                    .HasOne(p => p.Supplier)  // A Product has one Supplier
                    .WithMany(s => s.Products)  // A Supplier has many Products
                    .HasForeignKey(p => p.SupplierID)
                    .OnDelete(DeleteBehavior.SetNull);  // Optional: Configure cascading behavior

                // Configuring the relationship between Transactions and Products
                modelBuilder.Entity<Transactions>()
                    .HasOne(t => t.Product)  // A Transaction has one Product
                    .WithMany(p => p.Transactions)  // A Product has many Transactions
                    .HasForeignKey(t => t.ProductID)
                    .OnDelete(DeleteBehavior.Restrict);  // Optional: Configure cascading behavior

                // Configuring the relationship between Products and Customers
                modelBuilder.Entity<Products>()
                    .HasOne(p => p.Customer)  // A Product has one Customer
                    .WithMany(c => c.Products)  // A Customer has many Products
                    .HasForeignKey(p => p.CustomerID)
                    .OnDelete(DeleteBehavior.SetNull);  // Optional: Configure cascading behavior

                // Configuring the relationship between Products and Suppliers
                modelBuilder.Entity<Products>()
                    .HasOne(p => p.Supplier)  // A Product has one Supplier
                    .WithMany(s => s.Products)  // A Supplier has many Products
                    .HasForeignKey(p => p.SupplierID)
                    .OnDelete(DeleteBehavior.SetNull);  // Optional: Configure cascading behavior

                // Setting up primary keys for each entity
                modelBuilder.Entity<Customers>().HasKey(c => c.CustomerID);
                modelBuilder.Entity<Suppliers>().HasKey(s => s.SupplierID);
                modelBuilder.Entity<Products>().HasKey(p => p.ProductID);
                modelBuilder.Entity<Transactions>().HasKey(t => t.TransactionID);

                // Optional: Add any other configurations or indexes you may need here
            }

    }
}