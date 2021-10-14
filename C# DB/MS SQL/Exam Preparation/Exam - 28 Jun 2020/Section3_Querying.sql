SELECT Id, FORMAT(JourneyStart, 'dd/MM/yyyy') AS [JourneyStart], FORMAT(JourneyEnd, 'dd/MM/yyyy') AS [JourneyEnd]
FROM Journeys
WHERE Purpose = 'Military'
ORDER BY JourneyStart ASC

SELECT c.Id, CONCAT(c.FirstName, ' ', c.LastName) AS [full_name]
FROM Colonists AS c
JOIN TravelCards AS tc ON c.Id = tc.ColonistId
WHERE tc.JobDuringJourney = 'Pilot'
ORDER BY tc.ColonistId ASC

SELECT COUNT(*) AS [count]
FROM Colonists AS c
JOIN TravelCards AS t ON c.Id = t.ColonistId
JOIN Journeys AS j ON t.JourneyId = j.Id
WHERE j.Purpose = 'Technical'

SELECT s.[Name], s.Manufacturer
FROM Colonists AS c
JOIN TravelCards AS t ON c.Id = t.ColonistId
JOIN Journeys AS j ON t.JourneyId = j.Id
JOIN Spaceships AS s ON j.SpaceshipId = s.Id
WHERE DATEDIFF(YEAR, c.BirthDate, '01/01/2019') < 30
AND t.JobDuringJourney = 'Pilot'
ORDER BY s.[Name] ASC

SELECT p.[Name], COUNT(*) AS [JourneysCount]
FROM Planets AS p
JOIN Spaceports AS sp ON p.Id = sp.PlanetId
JOIN Journeys AS j ON sp.Id = j.DestinationSpaceportId
GROUP BY p.[Name]
ORDER BY JourneysCount DESC, p.[Name] ASC

SELECT *
FROM Colonists AS c 
JOIN TravelCards AS tc ON c.Id = tc.ColonistId

