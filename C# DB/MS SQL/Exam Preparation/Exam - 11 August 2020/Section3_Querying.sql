SELECT [Name], Price, [Description]
FROM Products
ORDER BY Price DESC, [Name]

SELECT f.ProductId, f.Rate, f.[Description], c.Id, c.Age, c.Gender
FROM Feedbacks AS f
JOIN Customers AS c ON f.CustomerId = c.Id
WHERE f.Rate < 5.0
ORDER BY f.ProductId DESC, f.Rate

SELECT CONCAT(c.FirstName, ' ', c.LastName) AS [CustomerName], c.PhoneNumber, c.Gender
FROM Customers AS c
LEFT JOIN Feedbacks AS f ON c.Id = f.CustomerId
WHERE f.CustomerId IS NULL
ORDER BY c.Id

SELECT c.FirstName, c.Age, c.PhoneNumber
FROM Customers AS c
JOIN Countries AS cs ON c.CountryId = cs.Id
WHERE c.Age >= 21 AND c.FirstName LIKE '%an%'
	  OR c.PhoneNumber LIKE '%38' AND cs.[Name] <> 'Greece'
ORDER BY c.FirstName, c.Age DESC

SELECT DistributorName, IngredientName, ProductName, AverageRate
FROM (SELECT d.[Name] AS [DistributorName], i.[Name] AS [IngredientName], p.[Name] AS [ProductName], AVG(f.Rate) AS [AverageRate]
	  FROM Distributors AS d
	  JOIN Ingredients AS i ON d.Id = i.DistributorId
	  JOIN ProductsIngredients AS [pi] ON i.Id = pi.IngredientId
	  JOIN Products AS p ON [pi].ProductId = p.Id
	  JOIN Feedbacks AS f ON p.Id = f.ProductId
	  GROUP BY d.[Name], i.[Name], p.[Name]) AS Result
WHERE AverageRate BETWEEN 5 AND 8
ORDER BY DistributorName, IngredientName, ProductName

SELECT c.[Name] AS [Countryname], d.[Name] AS [Distributorname]
	  FROM Countries AS c
	  JOIN Ingredients AS i ON c.Id = i.OriginCountryId
	  JOIN Distributors AS d ON c.Id = d.CountryId
	  GROUP BY c.[Name], d.[Name]
	  ORDER BY c.[Name], d.[Name], COUNT(i.[Name])