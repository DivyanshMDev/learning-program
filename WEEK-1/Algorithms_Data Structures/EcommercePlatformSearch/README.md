# E-commerce Platform Search Function

## What This Project Does
This project shows how to search for products in an e-commerce platform using two different methods.

## Big O Notation - Simple Explanation
Big O tells us how fast or slow an algorithm gets when we have more data:
- **O(1)** - Always the same speed (best)
- **O(log n)** - Gets a little slower as data grows (good)
- **O(n)** - Gets slower as data grows (okay for small data)

## Search Methods I Used

### Linear Search
- Looks at each product one by one until it finds the right one
- Like looking through a stack of papers from top to bottom
- Time: O(n) - slower for big lists

### Binary Search
- Only works if products are sorted by ID
- Cuts the search area in half each time
- Like finding a word in a dictionary
- Time: O(log n) - much faster for big lists

## When to Use Which?
- **Linear Search**: Small product lists, unsorted data
- **Binary Search**: Large product catalogs that are sorted

## Files in This Project
- `Product.cs` - The product class
- `SearchAlgorithms.cs` - The search methods
- `Program.cs` - Main program that tests everything
