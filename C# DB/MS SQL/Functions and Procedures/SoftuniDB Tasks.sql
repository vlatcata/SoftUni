-- 01 TASK
CREATE PROCEDURE usp_GetEmployeeSalaryAbove35000
AS
BEGIN
	DECLARE @SalaryEmployee DECIMAL = 35000
	SELECT e.FirstName, e.LastName
	FROM Employees AS e
	WHERE e.Salary > @SalaryEmployee
END

EXECUTE dbo.usp_GetEmployeeSalaryAbove35000

GO

-- 02 TASK
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber(@SalaryParameter DECIMAL(18, 4))
AS
BEGIN
	SELECT e.FirstName, e.LastName
	FROM Employees AS e
	WHERE e.Salary >= @SalaryParameter
END

EXECUTE usp_GetEmployeesSalaryAboveNumber @SalaryParameter = 48100

GO

-- 03 TASK
CREATE PROCEDURE usp_GetTownsStartingWith(@TownStartWith VARCHAR(30))
AS
BEGIN
	SELECT t.[Name]
	FROM Towns AS t
	WHERE LEFT(t.[Name], 1) = @TownStartWith
END

EXECUTE usp_GetTownsStartingWith @TownStartWith = 'b'

GO

--04 TASK
CREATE PROCEDURE usp_GetEmployeesFromTown(@TownName VARCHAR(30))
AS
BEGIN
	SELECT e.FirstName, e.LastName
	FROM Employees AS e
	LEFT JOIN Addresses AS a ON a.AddressID = e.AddressID
	LEFT JOIN Towns AS t ON t.TownID = a.TownID
	WHERE t.[Name] = @TownName
END

EXECUTE usp_GetEmployeesFromTown @TownName = 'Sofia'

GO

-- 05 TASK
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(30)
AS
BEGIN
	DECLARE @result NVARCHAR(10)

	IF(@salary < 30000)
		SET @result = 'Low'
	ELSE IF(@salary <= 50000)
		SET @result = 'Average'
	ELSE 
		SET @result = 'High'
	RETURN @result
END

SELECT e.Salary, dbo.ufn_GetSalaryLevel(e.Salary)
FROM Employees AS e

GO

--06 TASK

CREATE PROCEDURE usp_EmployeesBySalaryLevel(@LevelOfSalary VARCHAR(10))
AS
BEGIN
	SELECT r.FirstName AS [First Name], r.LastName AS [Last Name]
	FROM
		(SELECT e.FirstName, e.LastName, dbo.ufn_GetSalaryLevel(e.Salary) AS [Level]
		FROM Employees AS e) AS r
	WHERE r.[Level] = @LevelOfSalary
END

EXECUTE usp_EmployeesBySalaryLevel @LevelOfSalary = 'High'

GO

-- 07 TASK



GO

-- 08 TASK


