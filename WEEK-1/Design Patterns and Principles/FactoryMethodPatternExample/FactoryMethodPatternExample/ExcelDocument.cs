using System;

public class ExcelDocument : Document
{
    public override void Open()
    {
        Console.WriteLine("Opening Excel document...");
    }

    public override void Save()
    {
        Console.WriteLine("Saving Excel document...");
    }

    public override void Close()
    {
        Console.WriteLine("Closing Excel document...");
    }
}
