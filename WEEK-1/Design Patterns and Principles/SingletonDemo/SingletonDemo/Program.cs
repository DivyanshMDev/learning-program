// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main()
    {
        // Get the singleton instance and use it
        Logger logger1 = Logger.Instance;
        Logger logger2 = Logger.Instance;

        logger1.Log("Hello, Singleton!");

        
        if (logger1 == logger2)
        {
            Console.WriteLine("Both loggers are the same instance!");
        }
        else
        {
            Console.WriteLine("Loggers are different instances!");
        }
    }
}
