SELECT R.[Description], CONVERT(varchar, R.OpenDate,105) AS [OpenDate]
FROM Reports AS R
WHERE R.EmployeeId IS NULL
ORDER BY R.OpenDate , R.[Description]

SELECT r.[Description], c.[Name]
FROM Reports AS r
LEFT JOIN Categories AS c ON r.CategoryId = c.Id
ORDER BY r.[Description], c.[Name]

SELECT TOP(5) c.[Name], COUNT(*) AS [ReportsNumber]
FROM Categories AS c
JOIN Reports AS r ON c.Id = r.CategoryId
GROUP BY c.[Name]
ORDER BY [ReportsNumber] DESC, c.[Name]

SELECT u.Username, c.[Name]
FROM Users AS u
LEFT JOIN Reports AS r ON u.Id = r.UserId
LEFT JOIN Categories AS c ON r.CategoryId = c.Id
WHERE MONTH(r.OpenDate) = MONTH(u.Birthdate) AND DAY(r.OpenDate) = DAY(u.Birthdate)
ORDER BY u.Username, c.[Name]

SELECT CONCAT(e.FirstName, ' ', e.LastName) AS [FullName],
COUNT(DISTINCT r.UserId) AS [UsersCount]
FROM Employees AS e
LEFT JOIN Reports AS r ON e.Id = r.EmployeeId
GROUP BY e.Id, e.FirstName, e.LastName
ORDER BY [UsersCount] DESC, [FullName] ASC

SELECT ISNULL(e.FirstName + ' ' + e.LastName, 'None') AS [Employee],
	   ISNULL(d.[Name], 'None') AS [Department],
	   ISNULL(c.[Name], 'None') AS [Category],
	   r.[Description],
	   CONVERT(varchar, r.OpenDate, 104),
	   s.[Label] AS [Status],
	   u.[Name] AS [User]
FROM Reports AS r
LEFT JOIN Employees AS e ON r.EmployeeId = e.Id
LEFT JOIN Categories AS c ON c.Id = r.CategoryId
LEFT JOIN [Status] AS s ON s.Id = r.StatusId
LEFT JOIN Users AS u ON u.Id =  r.UserId
LEFT JOIN Departments AS d ON d.Id =  e.DepartmentId
ORDER BY e.FirstName DESC, e.LastName DESC, d.[Name], c.[Name], r.[Description], r.OpenDate, s.[Label], u.[Name]