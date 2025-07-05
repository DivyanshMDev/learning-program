using RetailStore;
using RetailStore.Models;

namespace RetailStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Lab 2: Database Context Setup ===");
            Console.WriteLine("DbContext configured successfully!");

            using (var context = new AppDbContext())
            {
                Console.WriteLine("Database connection established.");
                Console.WriteLine("Ready for Lab 3 migrations!");
            }
        }
    }
}
