using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Factory Method Pattern Demo ===\n");

        Console.WriteLine("1. Creating Word Document:");
        DocumentFactory wordFactory = new WordDocumentFactory();
        wordFactory.ProcessDocument();

        Console.WriteLine("\n2. Creating PDF Document:");
        DocumentFactory pdfFactory = new PdfDocumentFactory();
        pdfFactory.ProcessDocument();

        Console.WriteLine("\n3. Creating Excel Document:");
        DocumentFactory excelFactory = new ExcelDocumentFactory();
        excelFactory.ProcessDocument();

        Console.WriteLine("\n=== Demo Complete ===");
        Console.ReadKey(); 
    }
}
