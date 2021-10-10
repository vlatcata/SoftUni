CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
	DECLARE @result INT

	IF(@StartDate IS NULL OR @EndDate IS NULL)
	BEGIN
	     SET @result = 0
	END
		ELSE
	BEGIN
		 SET @result = DATEDIFF(HOUR, @StartDate, @EndDate)
	END

	RETURN @result
END

--SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
--FROM Reports

GO

CREATE PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
	DECLARE @EmployeeDepartment INT = (SELECT DepartmentId FROM Employees
									   WHERE Id = @EmployeeId)

	DECLARE @ReportDepartment INT = (SELECT c.DepartmentId
										FROM Reports AS r
									    JOIN Categories AS c ON r.CategoryId = c.Id
									    WHERE r.Id = @ReportId)
	
	IF(@EmployeeDepartment = @ReportDepartment)
	BEGIN
		UPDATE Reports
		SET EmployeeId = @EmployeeId
		WHERE Id = @ReportId
	END
		ELSE

		THROW 50005, 'Employee doesn''t belong to the appropriate department!', 1


--EXEC usp_AssignEmployeeToReport 30, 1
--EXEC usp_AssignEmployeeToReport 17, 2

