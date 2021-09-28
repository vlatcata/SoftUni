SELECT TOP(5) e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY a.AddressID ASC

SELECT TOP(50) e.FirstName, e.LastName, t.[Name], a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName

SELECT e.EmployeeID, e.FirstName, e.LastName, d.[Name]
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
AND d.[Name] = 'Sales'
ORDER BY e.EmployeeID ASC

SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.Name
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY d.DepartmentID ASC

SELECT TOP(3) e.EmployeeID, e.FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS p ON e.EmployeeID = p.EmployeeID
WHERE p.ProjectID IS NULL
ORDER BY e.EmployeeID ASC

SELECT e.FirstName, e.LastName, e.HireDate, d.[Name]
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '01-01-1999' AND d.[Name] IN ('Sales', 'Finance')
ORDER BY e.HireDate ASC

SELECT TOP(5) e.EmployeeID, e.FirstName, p.[Name]
FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID ASC

SELECT e.EmployeeID, e.FirstName,
CASE 
	WHEN YEAR(p.StartDate) >= 2005 THEN NULL
	ELSE p.[Name]
END AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24

SELECT E.EmployeeID, E.FirstName, E.ManagerID, M.FirstName AS ManagerName
FROM Employees AS E
JOIN Employees AS M ON M.EmployeeID = E.ManagerID 
WHERE E.ManagerID IN (3, 7)
ORDER BY E.EmployeeID

SELECT TOP(50) e.EmployeeID, e.FirstName + ' ' + e.LastName AS EmployeeName, es.FirstName + ' ' + es.LastName AS ManagerName, d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Employees AS es ON es.EmployeeID = e.ManagerID
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID ASC

SELECT TOP(1) AVG(Salary) AS AverageSalary
FROM Employees AS e
GROUP BY e.DepartmentID
ORDER BY AverageSalary