# Exercise 1: Ranking and Window Functions

## 📋 Overview
This exercise demonstrates SQL window functions for ranking data within partitions using MySQL.

## 🎯 Goal
Find the top 3 most expensive products in each category using ROW_NUMBER(), RANK(), and DENSE_RANK().

## 📁 Files
- `exercise1_all_queries.sql` - Complete solution with all queries
- `README.md` - This documentation

## 🔧 How to Run
1. Open MySQL Workbench
2. Connect to your local MySQL instance
3. Create a new schema called `learning_program`
4. Open and execute `exercise1_all_queries.sql`

## 📊 Key Concepts Learned
- **ROW_NUMBER()**: Unique sequential numbers (1,2,3,4...)
- **RANK()**: Same rank for ties, skips next (1,2,2,4...)
- **DENSE_RANK()**: Same rank for ties, no gaps (1,2,2,3...)
- **PARTITION BY**: Groups data for separate ranking
- **ORDER BY**: Determines ranking order

## 💡 Window Function Syntax
