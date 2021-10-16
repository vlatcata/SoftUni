CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN

	DECLARE @result INT =  (SELECT COUNT(*)
							FROM Clients AS c
							LEFT JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
							LEFT JOIN Cigars AS cs ON cc.CigarId = cs.Id
							WHERE c.FirstName = @name)

	RETURN @result
END

SELECT dbo.udf_ClientWithCigars('Betty')

GO

CREATE PROCEDURE usp_SearchByTaste(@taste VARCHAR(20))
AS
BEGIN
	
	SELECT c.CigarName, CONCAT('$', c.PriceForSingleCigar) AS [Price], t.TasteType, b.BrandName, CONCAT(s.[Length], ' cm') AS [CigarLength], CONCAT(s.RingRange, ' cm') AS [CigarRingRange]
	FROM Tastes AS t
	JOIN Cigars AS c ON t.Id = c.TastId
	JOIN Sizes AS s ON c.SizeId = s.Id
	JOIN Brands AS b ON c.BrandId = b.Id
	WHERE t.TasteType = @taste
	ORDER BY CigarLength, CigarRingRange DESC
END

EXEC usp_SearchByTaste 'Woody'