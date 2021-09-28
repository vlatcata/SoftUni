SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM Peaks AS p
JOIN Mountains AS m ON p.MountainId = m.Id
JOIN MountainsCountries AS mc ON mc.MountainId = m.Id
JOIN Countries AS c ON mc.CountryCode = c.CountryCode
WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

SELECT mc.CountryCode, COUNT(m.MountainRange) AS MountainRanges
FROM MountainsCountries AS mc
JOIN Mountains AS m ON mc.MountainId = m.Id
WHERE mc.CountryCode IN ('BG', 'US', 'RU')
GROUP BY mc.CountryCode

SELECT TOP(5) c.CountryName, r.RiverName
FROM CountriesRivers AS cr
JOIN Rivers AS r ON cr.RiverId = r.Id
RIGHT JOIN Countries AS c ON cr.CountryCode = c.CountryCode
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName ASC

SELECT ContinentCode, CurrencyCode, Total AS CurrencyUsage
FROM (SELECT ContinentCode, CurrencyCode, COUNT(*) AS Total,
DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY COUNT(*) DESC ) AS Ranked
FROM Countries
GROUP BY ContinentCode, CurrencyCode) AS k
WHERE Total > 1 AND Ranked = 1
ORDER BY ContinentCode, CurrencyCode

SELECT COUNT(*) AS [Count]
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
WHERE m.Id IS NULL

SELECT TOP(5) c.CountryName,
MAX(p.Elevation) AS HighestPeakElevation,
MAX(r.[Length]) AS LongestRiverLength
FROM Countries AS c
JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
JOIN Peaks AS p ON p.MountainId = mc.MountainId
JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
JOIN Rivers AS r ON r.Id = cr.RiverId
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, c.CountryName