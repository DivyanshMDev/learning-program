using RetailStore;
using RetailStore.Models;

namespace RetailStore
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Lab 4: Inserting Initial Data ===");

            using var context = new AppDbContext();

           
            var electronics = new Category { Name = "Electronics" };
            var groceries = new Category { Name = "Groceries" };
            await context.Categories.AddRangeAsync(electronics, groceries);

            
            var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
            var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };
            await context.Products.AddRangeAsync(product1, product2);

            await context.SaveChangesAsync();

            Console.WriteLine("✅ Data inserted successfully!");
            Console.WriteLine("- Added 2 categories: Electronics, Groceries");
            Console.WriteLine("- Added 2 products: Laptop (₹75,000), Rice Bag (₹1,200)");
        }
    }
}
