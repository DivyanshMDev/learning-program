using Microsoft.EntityFrameworkCore;
using RetailInventory.Domain;

namespace RetailInventory.Data
{
    public class RetailDbContext : DbContext
    {
        public RetailDbContext(DbContextOptions<RetailDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Product entity
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.ProductId);
                entity.Property(p => p.Price).HasColumnType("decimal(18,2)");
                entity.HasOne(p => p.Category)
                      .WithMany(c => c.Products)
                      .HasForeignKey(p => p.CategoryId);
            });

            // Configure Category entity
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.CategoryId);
            });

            // Seed data
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Electronics", Description = "Electronic devices and gadgets" },
                new Category { CategoryId = 2, Name = "Clothing", Description = "Apparel and accessories" },
                new Category { CategoryId = 3, Name = "Books", Description = "Books and educational materials" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Laptop", Description = "High-performance laptop", Price = 999.99m, StockQuantity = 50, CategoryId = 1, CreatedDate = new DateTime(2024, 1, 15, 10, 0, 0) },
                new Product { ProductId = 2, Name = "T-Shirt", Description = "Cotton t-shirt", Price = 19.99m, StockQuantity = 100, CategoryId = 2, CreatedDate = new DateTime(2024, 1, 16, 14, 30, 0) },
                new Product { ProductId = 3, Name = "Programming Book", Description = "Learn C# programming", Price = 49.99m, StockQuantity = 30, CategoryId = 3, CreatedDate = new DateTime(2024, 1, 17, 9, 45, 0) }
            );
        }
    }
}
