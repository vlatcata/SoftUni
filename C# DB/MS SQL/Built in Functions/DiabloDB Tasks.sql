SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start] FROM [Games]
WHERE YEAR([Start]) IN (2011, 2012)
ORDER BY [Start], [Name]

SELECT [Username], SUBSTRING([Email], CHARINDEX('@', [Email], 1) + 1, LEN([Email])) AS [Email Provider] FROM [Users]
ORDER BY [Email Provider], [Username]

SELECT [Username], [IpAddress] AS [IP Addresses] FROM [Users]
WHERE [IpAddress] LIKE  '___.1%.%.___'
ORDER BY [Username] ASC

SELECT [Name] AS [Game],
[Part of the Day] = CASE
						WHEN DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
						WHEN DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
						ELSE 'Evening'
					END
					, [Duration] = 
					CASE 
						WHEN [Duration] <= 3 THEN 'Extra Short'
						WHEN [Duration] <= 6 AND [Duration] >= 4 THEN 'Short'
						WHEN [Duration] > 6 THEN 'Long'
						ELSE 'Extra Long'
					END
FROM [Games]
ORDER BY [Name], [Duration], [Part of the Day]