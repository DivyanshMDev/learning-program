using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("E-commerce Search Demo\n");

        
        Product[] products = {
            new Product(101, "Laptop"),
            new Product(205, "T-Shirt"),
            new Product(150, "Phone"),
            new Product(303, "Coffee Mug")
        };

      
        Product[] sortedProducts = {
            new Product(101, "Laptop"),
            new Product(150, "Phone"),
            new Product(205, "T-Shirt"),
            new Product(303, "Coffee Mug")
        };

        int searchId = 205;
        Console.WriteLine($"Looking for product with ID: {searchId}\n");

    //linear search
        int linearResult = SearchAlgorithms.LinearSearch(products, searchId);
        if (linearResult != -1)
        {
            Console.WriteLine($"Linear Search: Found {products[linearResult]}");
        }
        else
        {
            Console.WriteLine("Linear Search: Not found");
        }

        //  Binary Search
        int binaryResult = SearchAlgorithms.BinarySearch(sortedProducts, searchId);
        if (binaryResult != -1)
        {
            Console.WriteLine($"Binary Search: Found {sortedProducts[binaryResult]}");
        }
        else
        {
            Console.WriteLine("Binary Search: Not found");
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
