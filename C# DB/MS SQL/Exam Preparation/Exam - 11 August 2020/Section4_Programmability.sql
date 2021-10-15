CREATE VIEW v_UserWithCountries AS
 SELECT CONCAT(c.FirstName, ' ', c.LastName) AS [CustomerName], c.Age, c.Gender, cs.[Name] AS [CountryName]
 FROM Customers AS c
 JOIN Countries AS cs ON c.CountryId = cs.Id

--SELECT TOP 5 *
--FROM v_UserWithCountries
--ORDER BY Age

CREATE TRIGGER t_DeleteProducts
ON Products
INSTEAD OF DELETE AS
BEGIN
	
	DECLARE @DeletedProducts INT = 
		(SELECT P.Id
			  FROM Products AS P 
					JOIN deleted AS D
						ON D.Id = P.Id)
	DELETE 
		FROM Feedbacks
		WHERE ProductId = @DeletedProducts

	DELETE
        FROM ProductsIngredients
        WHERE ProductId = @deletedProducts

    DELETE Products
        WHERE Id = @deletedProducts

END

--DELETE FROM Products WHERE Id = 7