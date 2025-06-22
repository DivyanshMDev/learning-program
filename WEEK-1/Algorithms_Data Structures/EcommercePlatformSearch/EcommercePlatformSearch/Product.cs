using System;

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }

    public Product(int id, string name)
    {
        ProductId = id;
        ProductName = name;
    }

    public override string ToString()
    {
        return $"ID: {ProductId}, Name: {ProductName}";
    }
}
