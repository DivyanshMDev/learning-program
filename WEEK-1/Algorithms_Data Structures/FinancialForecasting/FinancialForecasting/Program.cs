using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Financial Forecasting Tool ===\n");

        
        double initialAmount = 1000.0;
        double growthRate = 0.05; 
        int years = 10;

        Console.WriteLine($"Initial Investment: ${initialAmount:F2}");
        Console.WriteLine($"Annual Growth Rate: {growthRate * 100}%");
        Console.WriteLine($"Forecast Period: {years} years\n");

        Console.WriteLine("=== Basic Recursive Calculation ===");
        double futureValue = FinancialForecaster.CalculateFutureValue(initialAmount, growthRate, years);
        Console.WriteLine($"Future Value after {years} years: ${futureValue:F2}\n");


        Console.WriteLine("=== Year-by-Year Breakdown ===");
        ShowYearlyBreakdown(initialAmount, growthRate, years);


        Console.WriteLine("\n=== Optimized Calculation Demo ===");
        DemonstrateOptimization(initialAmount, growthRate);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static void ShowYearlyBreakdown(double amount, double rate, int years)
    {
        for (int year = 0; year <= years; year++)
        {
            double value = FinancialForecaster.CalculateFutureValue(amount, rate, year);
            Console.WriteLine($"Year {year}: ${value:F2}");
        }
    }

    static void DemonstrateOptimization(double amount, double rate)
    {
        Console.WriteLine("Calculating multiple forecasts (notice caching):");

        
        double result1 = FinancialForecaster.CalculateFutureValueOptimized(amount, rate, 5);
        Console.WriteLine($"5 years: ${result1:F2}");

        double result2 = FinancialForecaster.CalculateFutureValueOptimized(amount, rate, 5);
        Console.WriteLine($"5 years (cached): ${result2:F2}");

        double result3 = FinancialForecaster.CalculateFutureValueOptimized(amount, rate, 8);
        Console.WriteLine($"8 years: ${result3:F2}");
    }
}
