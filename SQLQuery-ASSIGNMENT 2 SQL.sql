USE AdventureWorks2019
/*
1. How many products can you find in the Production.Product table?
*/
GO
SELECT COUNT(DISTINCT ProductID) AS "Number of Products"
FROM Production.Product;

/*
2. Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.
*/
GO
SELECT COUNT(DISTINCT ProductID) AS "Number of Products"
FROM Production.Product p
JOIN Production.ProductSubcategory s ON p.ProductSubcategoryID = s.ProductSubcategoryID
WHERE p.ProductSubcategoryID IS NOT NULL;

/*
3. How many Products reside in each SubCategory? Write a query to display the results with the following titles.
ProductSubcategoryID CountedProducts
-------------------- ---------------
*/
GO
SELECT ProductSubcategoryID, COUNT(DISTINCT ProductID) AS CountedProducts
FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL
GROUP BY ProductSubcategoryID;

/*
4.  How many products that do not have a product subcategory.
*/
GO
SELECT COUNT(DISTINCT ProductID) AS CountedProducts
FROM Production.Product
WHERE ProductSubcategoryID IS NULL;

/*
5. Write a query to list the sum of products quantity of each product in the Production.ProductInventory table.
*/
GO
SELECT ProductID, SUM(Quantity) AS [Total Quantity]
FROM Production.ProductInventory
GROUP BY ProductID;

/*
6. Write a query to list the sum of products in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100.
ProductID    TheSum
---------    ------
*/
GO
SELECT ProductID, SUM(Quantity) AS TheSum
FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY ProductID
HAVING SUM(Quantity) < 100;

/*
7. Write a query to list the sum of products with the shelf information in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100
Shelf      ProductID    TheSum
-----      ---------    ------
*/
GO
SELECT Shelf, ProductID, SUM(Quantity) AS TheSum
FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY Shelf, ProductID
HAVING SUM(Quantity) < 100;

/*
8. Write the query to list the average quantity for products where column LocationID has the value of 10 from the table Production.ProductInventory table.
*/
GO
SELECT ProductID, AVG(Quantity) AS TheAverage
FROM Production.ProductInventory
WHERE LocationID = 10
GROUP BY ProductID;

/*
9. Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory
ProductID   Shelf      TheAvg
----------- ---------- -----------
*/
GO
SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
GROUP BY ProductID, Shelf;

/*
10. Write query  to see the average quantity  of  products by shelf excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory
ProductID   Shelf      TheAvg
----------- ---------- -----------
*/
GO
SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
WHERE NOT Shelf = 'N/A'
GROUP BY ProductID, Shelf;

/*
11. List the members (rows) and average list price in the Production.Product table. This should be grouped independently over the Color and the Class column. Exclude the rows where Color or Class are null.
Color          Class     TheCount          AvgPrice
-------------- ------    -----------       ---------------------
*/
GO
SELECT Color, Class, COUNT(DISTINCT ProductID) AS TheCount, AVG(ListPrice) AS AvgPrice
FROM Production.Product
WHERE Color IS NOT NULL AND Class IS NOT NULL
GROUP BY Color, Class;

/*
12. Write a query that lists the country and province names from person.CountryRegion and person.StateProvince tables. Join them and produce a result set similar to the following.
Country                        Province
---------                      ----------------------
*/
GO
SELECT c.Name AS Country, s.Name AS Province
FROM Person.CountryRegion c
JOIN Person.StateProvince s ON c.CountryRegionCode = s.CountryRegionCode;

/*
13. Write a query that lists the country and province names from person.CountryRegion and person.StateProvince tables and list the countries filter them by Germany and Canada. Join them and produce a result set similar to the following.
Country                        Province
---------                      ----------------------
*/
GO
SELECT c.Name AS Country, s.Name AS Province
FROM Person.StateProvince s
JOIN (
	SELECT Name, CountryRegionCode
	FROM Person.CountryRegion
	WHERE Name IN ('Germany', 'Canada')
) c ON c.CountryRegionCode = s.CountryRegionCode;

/* Using Northwind Database */
USE Northwind
/*
14. List all Products that has been sold at least once in last 27 years.
*/
GO
SELECT DISTINCT p.ProductName
FROM dbo.Products p
JOIN dbo.[Order Details] d ON p.ProductID = d.ProductID
JOIN dbo.Orders o ON d.OrderID = o.OrderID
WHERE o.OrderDate >= DATEADD(YEAR, -27, GETDATE());

/*
15. List top 5 locations (Zip Code) where the products sold most.
*/
GO
SELECT TOP 5 ShipPostalCode, COUNT(ShipPostalCode) AS Frequency
FROM dbo.Orders
GROUP BY ShipPostalCode
ORDER BY Frequency DESC;

/*
16. List top 5 locations (Zip Code) where the products sold most in last 27 years.
*/
GO
SELECT TOP 5 ShipPostalCode, COUNT(ShipPostalCode) AS Frequency
FROM dbo.Orders
WHERE OrderDate >= DATEADD(YEAR, -27, GETDATE())
GROUP BY ShipPostalCode
ORDER BY Frequency DESC;

/*
17. List all city names and number of customers in that city.
*/
GO
SELECT City, COUNT(City) AS NumberOfCustomers
FROM dbo.Customers
GROUP BY City;

/*
18. List city names which have more than 2 customers, and number of customers in that city
*/
GO
SELECT City, COUNT(City) AS NumberOfCustomers
FROM dbo.Customers
GROUP BY City
HAVING COUNT(City) > 2;

/*
19. List the names of customers who placed orders after 1/1/98 with order date.
*/
GO
SELECT c.CompanyName, o.OrderDate
FROM dbo.Customers c
JOIN dbo.Orders o ON c.CustomerID = o.CustomerID
WHERE o.OrderDate > '1998-01-01 00:00:00.000';

/*
20. List the names of all customers with most recent order dates
*/
GO
SELECT c.CompanyName, MAX(o.OrderDate) AS MostRecentOrderDate
FROM dbo.Customers c
JOIN dbo.Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.CompanyName
ORDER BY MostRecentOrderDate DESC;

/*
21. Display the names of all customers  along with the  count of products they bought
*/
GO
SELECT c.CompanyName, SUM(d.Quantity) AS CountOfProducts
FROM dbo.Customers c
JOIN dbo.Orders o ON c.CustomerID = o.CustomerID
JOIN dbo.[Order Details] d ON o.OrderID = d.OrderID
GROUP BY c.CompanyName;

/*
22. Display the customer ids who bought more than 100 Products with count of products.
*/
GO
SELECT c.CustomerID, SUM(d.Quantity) AS CountOfProducts
FROM dbo.Customers c
JOIN dbo.Orders o ON c.CustomerID = o.CustomerID
JOIN dbo.[Order Details] d ON o.OrderID = d.OrderID
GROUP BY c.CustomerID
HAVING SUM(d.Quantity) > 100;

/*
23. List all of the possible ways that suppliers can ship their products. Display the results as below
Supplier Company Name                Shipping Company Name
-------------------------            -------------------------
*/
GO
SELECT DISTINCT sup.CompanyName AS "Supplier Company Name", ship.CompanyName AS "Shipping Company Name"
FROM dbo.Suppliers sup
JOIN dbo.Products prd ON sup.SupplierID = prd.SupplierID
JOIN dbo.[Order Details] od ON prd.ProductID = od.ProductID
JOIN dbo.Orders o ON od.OrderID = o.OrderID
JOIN dbo.Shippers ship ON o.ShipVia = ship.ShipperID;

/*
24. Display the products order each day. Show Order date and Product Name.
*/
GO
SELECT o.OrderDate, p.ProductName
FROM dbo.Orders o
JOIN dbo.[Order Details] od ON o.OrderID = od.OrderID
JOIN dbo.Products p ON od.ProductID = p.ProductID
ORDER BY o.OrderDate;

/*
25. Displays pairs of employees who have the same job title.
*/
GO
SELECT e1.Title, e1.FirstName AS "Employee 1 First Name", e2.FirstName AS "Employee 2 First Name"
FROM dbo.Employees e1
JOIN dbo.Employees e2 ON e1.Title = e2.Title AND e1.EmployeeID < e2.EmployeeID;

/*
26. Display all the Managers who have more than 2 employees reporting to them.
*/
GO
SELECT e1.FirstName AS "Manager First Name", COUNT(e2.EmployeeID) AS "Number of Reports"
FROM dbo.Employees e1
JOIN dbo.Employees e2 ON e1.EmployeeID = e2.ReportsTo
GROUP BY e1.FirstName
HAVING COUNT(e2.EmployeeID) > 2
ORDER BY [Number of Reports] DESC;

/*
27. Display the customers and suppliers by city. The results should have the following columns
City
Name
Contact Name,
Type (Customer or Supplier)
*/
GO
SELECT City, CompanyName AS Name, ContactName AS "Contact Name", 'Customer' AS Type
FROM dbo.Customers
UNION ALL

SELECT City, CompanyName AS Name, ContactName AS "Contact Name", 'Supplier' AS Type
FROM dbo.Suppliers
ORDER BY City, Type;