# Financial Forecasting Tool

## What This Project Does
This tool predicts future investment values using recursive algorithms. It shows how much money you'll have after a certain number of years with compound growth.

## Recursion Explained Simply
Recursion is like asking "What will my money be worth next year?" and then asking the same question about that amount, year after year, until you reach your target year.

Think of it like climbing stairs:
- To get to the 10th step, first get to the 9th step
- To get to the 9th step, first get to the 8th step
- Keep going until you reach the ground (base case)

## How the Algorithm Works

## Basic Recursive Formula
FutureValue(amount, rate, years) =
if years == 0: return amount
else: FutureValue(amount * (1 + rate), rate, years - 1)


### Example
- Start: $1000, 5% growth, 10 years
- Year 1: $1000 × 1.05 = $1050
- Year 2: $1050 × 1.05 = $1102.50
- Continue for 10 years...

## Time Complexity Analysis
- **Basic Recursion**: O(n) where n = number of years
- **With Memoization**: O(n) but much faster for repeated calculations
- **Space Complexity**: O(n) due to recursive call stack

## Optimization Techniques
1. **Memoization**: Store previously calculated results
2. **Iterative Approach**: Use loops instead of recursion for better memory usage
3. **Tail Recursion**: Structure recursion to be more memory efficient

## Files in This Project
- `FinancialForecaster.cs` - Main calculation logic
- `Program.cs` - Demo and testing
- `README.md` - This documentation
