using System;

public class PdfDocument : Document
{
    public override void Open()
    {
        Console.WriteLine("Opening PDF document...");
    }

    public override void Save()
    {
        Console.WriteLine("Saving PDF document...");
    }

    public override void Close()
    {
        Console.WriteLine("Closing PDF document...");
    }
}
