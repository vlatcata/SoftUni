SELECT CigarName, PriceForSingleCigar, ImageURL
FROM Cigars
ORDER BY PriceForSingleCigar, CigarName DESC

SELECT c.Id, c.CigarName, c.PriceForSingleCigar, t.TasteType, t.TasteStrength
FROM Cigars AS c
JOIN Tastes AS t ON c.TastId = t.Id
WHERE t.TasteType = 'Earthy' OR t.TasteType = 'Woody'
ORDER BY c.PriceForSingleCigar DESC

SELECT c.Id, CONCAT(c.FirstName, ' ', c.LastName) AS [ClientName], c.Email
FROM Clients AS c
LEFT JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
LEFT JOIN Cigars AS cs ON cc.CigarId = cs.Id
WHERE cs.CigarName IS NULL
ORDER BY ClientName

SELECT TOP(5) c.CigarName, c.PriceForSingleCigar, c.ImageURL
FROM Sizes AS S
LEFT JOIN Cigars AS c ON s.Id = c.SizeId
WHERE (s.[Length] >= 12 AND c.CigarName LIKE '%ci%')
	  OR
	  (c.PriceForSingleCigar > 50 AND s.RingRange > 2.55)
ORDER BY c.CigarName, c.PriceForSingleCigar DESC

SELECT CONCAT(c.FirstName, ' ', c.LastName) AS [Fullname], a.Country, a.ZIP, CONCAT('$', MAX(cs.PriceForSingleCigar)) AS [CigarPrice]
FROM Clients AS c
JOIN Addresses AS a ON c.AddressId = a.Id
JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
JOIN Cigars AS cs ON cc.CigarId = cs.Id
WHERE a.ZIP NOT LIKE '%[^0-9.]%'
GROUP BY c.FirstName, c.LastName, a.Country, a.ZIP

SELECT c.LastName, AVG(s.[Length]) AS [CigarLength], CEILING(AVG(s.RingRange)) AS [CigarRingRange]
FROM Clients AS c
JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
JOIN Cigars AS cs ON cc.CigarId = cs.Id
JOIN Sizes AS s ON cs.SizeId = s.Id
GROUP BY c.LastName
ORDER BY CigarLength DESC