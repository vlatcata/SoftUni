SELECT a.FirstName, a.LastName, FORMAT(a.BirthDate, 'MM-dd-yyyy') AS [Birthdate], c.[Name] AS [Hometown], a.Email
FROM Accounts AS a
LEFT JOIN Cities AS c ON a.CityId = c.Id
WHERE LEFT(a.Email, 1) = 'e'
ORDER BY c.[Name] ASC

SELECT c.[Name], COUNT(*) AS [Hotels]
FROM Cities AS c
RIGHT JOIN Hotels AS h ON c.Id = h.CityId
GROUP BY c.[Name]
ORDER BY Hotels DESC, c.[Name]

SELECT a.Id, CONCAT(a.FirstName, ' ', a.LastName) AS [FullName],
		     MAX(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS [LongestTrip],
			 MIN(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS [ShortestTrip]
FROM Accounts AS a
JOIN AccountsTrips AS [at] ON A.Id = [at].AccountId
JOIN Trips AS t ON [at].TripId = t.Id
WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
GROUP BY a.Id, a.FirstName, a.LastName
ORDER BY LongestTrip DESC, ShortestTrip ASC

SELECT TOP(10) c.Id, c.[Name], c.CountryCode, COUNT(*) AS [Accounts]
FROM Cities AS c
JOIN Accounts AS a ON c.Id = a.CityId
GROUP BY c.Id, c.[Name], c.CountryCode
ORDER BY Accounts DESC

SELECT a.Id, a.Email, c.[Name] AS [City], COUNT(*) AS [Trips]
FROM Accounts AS a
JOIN AccountsTrips AS [at] ON a.Id = [at].AccountId
JOIN Trips AS t ON t.Id = [at].TripId
JOIN Rooms AS r ON r.Id = t.RoomId
JOIN Hotels AS h ON h.Id = r.HotelId
JOIN Cities AS c ON c.Id = h.CityId
WHERE a.CityId = c.Id
GROUP BY a.Id, a.Email, c.[Name]
ORDER BY Trips DESC, a.Id

SELECT t.Id,
		CASE
			WHEN a.MiddleName IS NULL THEN CONCAT(a.FirstName, ' ', a.LastName)
		    ELSE CONCAT(a.FirstName, ' ', a.MiddleName, ' ', a.LastName)
			END AS [Full Name],
	   c.[Name] AS [From],
	   c2.[Name] AS [To],
	   CASE
			WHEN T.CancelDate IS NULL THEN CONCAT(DATEDIFF(DAY,T.ArrivalDate, T.ReturnDate), ' ', 'days')
			ELSE 'Canceled'
			END AS [Duration]
FROM AccountsTrips AS [AT]
JOIN Accounts      AS A    ON    A.Id  = [AT].AccountId
JOIN Cities        AS C    ON    C.Id  = A.CityId
JOIN Trips         AS T    ON    T.Id  = [AT].TripId
JOIN Rooms         AS R    ON    R.Id  = T.RoomId
JOIN Hotels        AS H    ON    H.Id  = R.HotelId
JOIN Cities        AS C2    ON   C2.Id = H.CityId
ORDER BY [Full Name], t.Id