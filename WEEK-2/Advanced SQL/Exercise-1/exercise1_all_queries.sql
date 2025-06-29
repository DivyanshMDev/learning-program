CREATE DATABASE learning_program;

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);

INSERT INTO Products VALUES 
(1, 'iPhone 14', 'Electronics', 999.99),
(2, 'Samsung Galaxy S23', 'Electronics', 899.99),
(3, 'iPad Pro', 'Electronics', 1099.99),
(4, 'MacBook Pro', 'Electronics', 1299.99),
(5, 'Nike Air Max', 'Clothing', 129.99),
(6, 'Adidas Ultraboost', 'Clothing', 149.99),
(7, 'Levi Jeans', 'Clothing', 79.99),
(8, 'Designer Jacket', 'Clothing', 299.99),
(9, 'Coffee Maker', 'Home', 89.99),
(10, 'Blender', 'Home', 79.99),
(11, 'Air Fryer', 'Home', 129.99),
(12, 'Robot Vacuum', 'Home', 399.99);


SELECT 
    ProductID,
    ProductName,
    Category,
    Price,
    ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) as RowNum
FROM Products
ORDER BY Category, Price DESC;

SELECT 
    ProductID,
    ProductName,
    Category,
    Price,
    RANK() OVER (PARTITION BY Category ORDER BY Price DESC) as RankNum
FROM Products
ORDER BY Category, Price DESC;

SELECT 
    ProductID,
    ProductName,
    Category,
    Price,
    DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) as DenseRankNum
FROM Products
ORDER BY Category, Price DESC;


-- Corrected version using subquery
SELECT 
    ProductID,
    ProductName,
    Category,
    Price,
    RowNum,
    RankNum,
    DenseRankNum
FROM (
    SELECT 
        ProductID,
        ProductName,
        Category,
        Price,
        ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) as RowNum,
        RANK() OVER (PARTITION BY Category ORDER BY Price DESC) as RankNum,
        DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) as DenseRankNum
    FROM Products
) AS RankedProducts
WHERE RowNum <= 3
ORDER BY Category, Price DESC;
