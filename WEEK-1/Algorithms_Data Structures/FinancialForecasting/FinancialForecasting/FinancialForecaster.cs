using System;

public class FinancialForecaster
{
    
    public static double CalculateFutureValue(double presentValue, double growthRate, int years)
    {
        
        if (years == 0)
        {
            return presentValue;
        }

      
        double nextYearValue = presentValue * (1 + growthRate);
        return CalculateFutureValue(nextYearValue, growthRate, years - 1);
    }

    
    private static Dictionary<string, double> memo = new Dictionary<string, double>();

    public static double CalculateFutureValueOptimized(double presentValue, double growthRate, int years)
    {
        string key = $"{presentValue}_{growthRate}_{years}";

        
        if (memo.ContainsKey(key))
        {
            Console.WriteLine($"Using cached result for {years} years");
            return memo[key];
        }

       
        if (years == 0)
        {
            return presentValue;
        }

       
        double nextYearValue = presentValue * (1 + growthRate);
        double result = CalculateFutureValueOptimized(nextYearValue, growthRate, years - 1);

        
        memo[key] = result;
        return result;
    }
}
