/*
1. Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, with no filter. 
*/
GO
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product;

/*
2. Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, excludes the rows that ListPrice is 0. 
*/
GO
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product WHERE NOT ListPrice = 0;

/*
3. Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, the rows that are NULL for the Color column.
*/
GO
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product WHERE Color IS NULL;

/*
4. Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, the rows that are not NULL for the Color column.
*/
GO
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product WHERE Color IS NOT NULL;

/*
5. Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, the rows that are not NULL for the column Color, and the column ListPrice has a value greater than zero.
*/
GO
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product WHERE (Color IS NOT NULL) AND (ListPrice > 0);

/*
6. Write a query that concatenates the columns Name and Color from the Production.Product table by excluding the rows that are null for color.
*/
GO
SELECT CONCAT(Name, ' ', Color) AS "Name and Color"
FROM Production.Product WHERE Color IS NOT NULL;

/*
7. Write a query that generates the following result set  from Production.Product:
NAME: LL Crankarm  --  COLOR: Black
NAME: ML Crankarm  --  COLOR: Black
NAME: HL Crankarm  --  COLOR: Black
NAME: Chainring Bolts  --  COLOR: Silver
NAME: Chainring Nut  --  COLOR: Silver
NAME: Chainring  --  COLOR: Black
*/
GO
SELECT CONCAT('NAME: ', Name, '  --  COLOR: ', Color) AS "Name and Color Specific"
FROM Production.Product
WHERE 
    (Name = 'LL Crankarm' AND Color = 'Black') OR
    (Name = 'ML Crankarm' AND Color = 'Black') OR
    (Name = 'HL Crankarm' AND Color = 'Black') OR
    (Name = 'Chainring Bolts' AND Color = 'Silver') OR
    (Name = 'Chainring Nut' AND Color = 'Silver') OR
    (Name = 'Chainring' AND Color = 'Black');

/*
8. Write a query to retrieve the to the columns ProductID and Name from the Production.Product table filtered by ProductID from 400 to 500
*/
GO
SELECT ProductID, Name
FROM Production.Product WHERE ProductID BETWEEN 400 AND 500;

/*
9. Write a query to retrieve the to the columns  ProductID, Name and color from the Production.Product table restricted to the colors black and blue
*/
GO
SELECT ProductID, Name, Color
FROM Production.Product WHERE Color IN ('Black', 'Blue');

/*
10. Write a query to get a result set on products that begins with the letter S.
*/
GO
SELECT *
FROM Production.Product WHERE Name LIKE 'S%';

/*
11. Write a query that retrieves the columns Name and ListPrice from the Production.Product table. Your result set should look something like the following. Order the result set by the Name column. 
Name                                    ListPrice
Seat Lug                                0,00
Seat Post                               0,00
Seat Stays                              0,00
Seat Tube                               0,00
Short-Sleeve Classic Jersey, L          53,99
Short-Sleeve Classic Jersey, M          53,99
*/
GO
SELECT Name, ListPrice
FROM Production.Product WHERE Name LIKE 'S%' ORDER BY Name;

/*
12. Write a query that retrieves the columns Name and ListPrice from the Production.Product table. Your result set should look something like the following. Order the result set by the Name column. The products name should start with either 'A' or 'S'
Name                                    ListPrice
Adjustable Race                         0,00
All-Purpose Bike Stand                  159,00
AWC Logo Cap                            8,99
Seat Lug                                0,00
Seat Post                               0,00
*/
GO
SELECT Name, ListPrice
FROM Production.Product WHERE Name LIKE 'A%' OR Name LIKE 'S%' ORDER BY Name;

/*
13. Write a query so you retrieve rows that have a Name that begins with the letters SPO, but is then not followed by the letter K. After this zero or more letters can exists. Order the result set by the Name column.
*/
GO
SELECT *
FROM Production.Product WHERE Name LIKE 'SPO%' AND Name NOT LIKE 'SPOK%' ORDER BY Name;

/*
14. Write a query that retrieves unique colors from the table Production.Product. Order the results in descending manner.
*/
GO
SELECT DISTINCT Color
FROM Production.Product WHERE Color IS NOT NULL ORDER BY Color DESC;