USE Northwind

/*
1. List all cities that have both Employees and Customers.
*/
GO
SELECT DISTINCT City
FROM Customers
WHERE City IN (SELECT City FROM Employees);

/*
2. List all cities that have Customers but no Employee.
*/
/* a.      Use sub-query */
GO
SELECT DISTINCT City
FROM Customers
WHERE CITY NOT IN (SELECT City FROM Employees);
/* b.      Do not use sub-query */
GO
SELECT DISTINCT c.City
FROM Customers c
LEFT JOIN Employees e ON c.City = e.City
WHERE e.City IS NULL;

/*
3. List all products and their total order quantities throughout all orders.
*/
GO
SELECT p.ProductName, SUM(od.Quantity) AS TotalOderQuantities
FROM Products p
JOIN [Order Details] od ON p.ProductID = od.ProductID
GROUP BY p.ProductName;

/*
4. List all Customer Cities and total products ordered by that city.
*/
GO
SELECT c.City, (
	SELECT SUM(od.Quantity)
	FROM [Order Details] od
	JOIN Orders o ON od.OrderID = o.OrderID
	WHERE c.City = o.ShipCity) AS TotalProductsOrdered
FROM Customers c
GROUP BY c.City;

/*
5. List all Customer Cities that have at least two customers.
*/
GO
SELECT City
FROM Customers
GROUP BY City
HAVING COUNT(City) >= 2;

/*
6. List all Customer Cities that have ordered at least two different kinds of products.
*/
GO
SELECT o.ShipCity
FROM Orders o
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY o.ShipCity
HAVING COUNT(DISTINCT od.ProductID) >= 2;

/*
7. List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.
*/
GO
SELECT c.CustomerID, c.CompanyName, c.City AS CustomerCity
FROM Customers c
WHERE c.CustomerID IN (
    SELECT o.CustomerID
    FROM Orders o
    WHERE o.ShipCity <> (
        SELECT c2.City 
        FROM Customers c2 
        WHERE c2.CustomerID = o.CustomerID
    )
);

/*
8. List 5 most popular products, their average price, and the customer city that ordered most quantity of it.
*/
GO
CREATE TABLE #ProductQuantities (
    ProductID INT,
    ProductName NVARCHAR(255),
    TotalQuantity INT,
    AveragePrice DECIMAL(18, 2),
    CustomerID NVARCHAR(255)
);

INSERT INTO #ProductQuantities (ProductID, ProductName, TotalQuantity, AveragePrice, CustomerID)
SELECT
    od.ProductID,
    p.ProductName,
    SUM(od.Quantity) AS TotalQuantity,
    AVG(od.UnitPrice) AS AveragePrice,
    o.CustomerID
FROM
    [Order Details] od
JOIN
    Orders o ON od.OrderID = o.OrderID
JOIN
    Products p ON od.ProductID = p.ProductID
GROUP BY
    od.ProductID, p.ProductName, o.CustomerID;

CREATE TABLE #TopProducts (
    ProductID INT,
    ProductName NVARCHAR(255),
    TotalQuantity INT,
    AveragePrice DECIMAL(18, 2)
);

INSERT INTO #TopProducts (ProductID, ProductName, TotalQuantity, AveragePrice)
SELECT
    ProductID,
    ProductName,
    SUM(TotalQuantity) AS TotalQuantity,
    AVG(AveragePrice) AS AveragePrice
FROM
    #ProductQuantities
GROUP BY
    ProductID, ProductName
ORDER BY
    TotalQuantity DESC
OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY;

CREATE TABLE #CityQuantities (
    ProductID INT,
    City NVARCHAR(255),
    CityQuantity INT
);

INSERT INTO #CityQuantities (ProductID, City, CityQuantity)
SELECT
    pq.ProductID,
    c.City,
    SUM(pq.TotalQuantity) AS CityQuantity
FROM
    #ProductQuantities pq
JOIN
    Orders o ON pq.CustomerID = o.CustomerID
JOIN
    Customers c ON o.CustomerID = c.CustomerID
GROUP BY
    pq.ProductID, c.City;

SELECT
    tp.ProductID,
    tp.ProductName,
    tp.AveragePrice,
    cq.City,
    cq.CityQuantity
FROM
    #TopProducts tp
JOIN
    (SELECT
         ProductID,
         City,
         CityQuantity,
         ROW_NUMBER() OVER (PARTITION BY ProductID ORDER BY CityQuantity DESC) AS rn
     FROM
         #CityQuantities) cq
ON
    tp.ProductID = cq.ProductID
WHERE
    cq.rn = 1
ORDER BY
    tp.TotalQuantity DESC;

DROP TABLE #ProductQuantities;
DROP TABLE #TopProducts;
DROP TABLE #CityQuantities;

/*
9. List all cities that have never ordered something but we have employees there.
*/
/* a.      Use sub-query */
GO
SELECT DISTINCT e.City
FROM Employees e
WHERE e.City NOT IN (
    SELECT DISTINCT o.ShipCity
    FROM Orders o
);
/* b.      Do not use sub-query */
GO
SELECT DISTINCT e.City
FROM Employees e
LEFT JOIN Orders o ON e.City = o.ShipCity
WHERE o.ShipCity IS NULL;

/*
10. List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered from. (tip: join  sub-query)
*/
GO
CREATE TABLE #MostOrdersCity (
    City NVARCHAR(255),
    OrderCount INT
);

INSERT INTO #MostOrdersCity (City, OrderCount)
SELECT TOP 1 e.City, COUNT(o.OrderID) AS OrderCount
FROM Employees e
JOIN Orders o ON e.EmployeeID = o.EmployeeID
GROUP BY e.City
ORDER BY COUNT(o.OrderID) DESC;

CREATE TABLE #MostQuantityCity (
    ShipCity NVARCHAR(255),
    TotalQuantity INT
);

INSERT INTO #MostQuantityCity (ShipCity, TotalQuantity)
SELECT TOP 1 o.ShipCity, SUM(od.Quantity) AS TotalQuantity
FROM Orders o
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY o.ShipCity
ORDER BY SUM(od.Quantity) DESC;

SELECT
    moc.City AS CityWithMostOrders,
    mqc.ShipCity AS CityWithMostQuantity
FROM
    #MostOrdersCity moc
JOIN
    #MostQuantityCity mqc
ON
    moc.City = mqc.ShipCity;

DROP TABLE #MostOrdersCity;
DROP TABLE #MostQuantityCity;

/*
11. How do you remove the duplicates record of a table?
*/
/* Create a temporary table to store unique records */
CREATE TABLE #TempTable (
    Column1 DataType,
    Column2 DataType,
    ...
);
/* Insert unique records into the temporary table */
INSERT INTO #TempTable (Column1, Column2, ...)
SELECT DISTINCT Column1, Column2, ...
FROM YourTable;
/* Truncate the original table */
TRUNCATE TABLE YourTable;
/* Insert the unique records back into the original table */
INSERT INTO YourTable (Column1, Column2, ...)
SELECT Column1, Column2, ...
FROM #TempTable;
/* Drop the temporary table */
DROP TABLE #TempTable;