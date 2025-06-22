using System;

public class WordDocument : Document
{
    public override void Open()
    {
        Console.WriteLine("Opening Word document...");
    }

    public override void Save()
    {
        Console.WriteLine("Saving Word document...");
    }

    public override void Close()
    {
        Console.WriteLine("Closing Word document...");
    }
}
