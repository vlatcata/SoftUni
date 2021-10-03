SELECT e.DepartmentID, SUM(e.Salary) AS TotalSalary
FROM Employees AS e
GROUP BY e.DepartmentID
ORDER BY e.DepartmentID

SELECT e.DepartmentID, MIN(e.Salary) AS MinimumSalary
FROM Employees AS e
WHERE e.DepartmentID IN (2, 5, 7) AND e.HireDate > '01/01/2000'
GROUP BY e.DepartmentID

GO

SELECT * INTO EmployeesWithSalaryOver30000
FROM Employees AS e
WHERE E.Salary > 30000

DELETE FROM EmployeesWithSalaryOver30000
WHERE ManagerID = 42

UPDATE EmployeesWithSalaryOver30000
SET Salary += 5000
WHERE DepartmentID = 1

SELECT e.DepartmentID, AVG(e.Salary) AS AverageSalary
FROM EmployeesWithSalaryOver30000 AS e
GROUP BY e.DepartmentID

GO

SELECT e.DepartmentID, MAX(e.Salary) AS MaxSalary
FROM Employees AS e
GROUP BY e.DepartmentID
HAVING MAX(e.Salary) < 30000 OR MAX(e.Salary) > 70000

SELECT COUNT(*) AS [Count]
FROM Employees AS e
WHERE e.ManagerID IS NULL

SELECT DISTINCT DepartmentID, Salary AS ThirdHighestSalary
FROM (SELECT
		e.DepartmentID,
		e.Salary,
		DENSE_RANK() OVER(PARTITION BY e.DepartmentID ORDER BY e.Salary) AS Ranks
		FROM Employees AS e) AS SalaryRanking
WHERE Ranks = 3

