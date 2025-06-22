using System;

public class SearchAlgorithms
{

    public static int LinearSearch(Product[] products, int targetId)
    {
        for (int i = 0; i < products.Length; i++)
        {
            if (products[i].ProductId == targetId)
            {
                return i; 
            }
        }
        return -1; 
    }

    
    public static int BinarySearch(Product[] sortedProducts, int targetId)
    {
        int left = 0;
        int right = sortedProducts.Length - 1;

        while (left <= right)
        {
            int middle = (left + right) / 2;

            if (sortedProducts[middle].ProductId == targetId)
            {
                return middle; 
            }
            else if (sortedProducts[middle].ProductId < targetId)
            {
                left = middle + 1; 
            }
            else
            {
                right = middle - 1; 
            }
        }
        return -1; 
    }
}
