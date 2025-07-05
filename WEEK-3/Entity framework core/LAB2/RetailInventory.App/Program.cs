using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RetailInventory.Data;
using RetailInventory.Domain;

namespace RetailInventory.App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Build configuration
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            // Setup dependency injection
            var services = new ServiceCollection();
            services.AddDbContext<RetailDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            var serviceProvider = services.BuildServiceProvider();

            // Get DbContext
            using var context = serviceProvider.GetRequiredService<RetailDbContext>();

            Console.WriteLine("=== Lab 2: Retail Inventory System ===");
            Console.WriteLine("Multi-layered EF Core project structure demonstration");
            Console.WriteLine("Database connection established!");

            // Display categories
            var categories = await context.Categories.ToListAsync();
            Console.WriteLine("\n📂 Categories:");
            foreach (var category in categories)
            {
                Console.WriteLine($"   • {category.Name}: {category.Description}");
            }

            // Display products with categories
            var products = await context.Products
                .Include(p => p.Category)
                .ToListAsync();

            Console.WriteLine("\n📦 Products:");
            foreach (var product in products)
            {
                Console.WriteLine($"   • {product.Name} ({product.Category.Name})");
                Console.WriteLine($"     Price: ${product.Price:F2} | Stock: {product.StockQuantity}");
                Console.WriteLine($"     Description: {product.Description}");
                Console.WriteLine();
            }

            Console.WriteLine("✅ Lab 2 completed successfully!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
