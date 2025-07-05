using Microsoft.EntityFrameworkCore;
using RetailStore.Models;

namespace RetailStore
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RetailStoreDb;Trusted_Connection=True;");
        }
    }
}
