-- 09 TASK

CREATE PROCEDURE usp_GetHoldersFullName
AS
BEGIN
	SELECT ah.FirstName + ' ' + ah.LastName AS [Full Name]
	FROM AccountHolders AS ah
END

EXECUTE usp_GetHoldersFullName

GO

-- 10 TASK

CREATE OR ALTER PROCEDURE usp_GetHoldersWithBalanceHigherThan(@Number DECIMAL(18, 4))
AS
BEGIN
	SELECT ah.FirstName AS [First Name], ah.LastName AS [Last Name]
	FROM AccountHolders AS ah
	LEFT JOIN Accounts AS a ON a.Id = ah.Id
	GROUP BY ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @Number
	ORDER BY ah.FirstName, ah.LastName
END

EXECUTE usp_GetHoldersWithBalanceHigherThan @Number = 540

GO

-- 11 TASK

CREATE FUNCTION ufn_CalculateFutureValue(@Sum DECIMAL(18, 4), @YearlyInterestRate FLOAT, @NumberOfYears DECIMAL(18, 4))
RETURNS DECIMAL(18, 4)
BEGIN
	DECLARE @Result DECIMAL(18, 4)
	SELECT @Result = @Sum * (POWER((1 + @YearlyInterestRate), @NumberOfYears))
	RETURN @Result
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

GO

-- 12 TASK

CREATE PROCEDURE usp_CalculateFutureValueForAccount(@AccountId INT, @interestRate FLOAT = 0.1)
AS
BEGIN
	SELECT @AccountId AS [Account Id],
	ah.FirstName AS [First Name],
	ah.LastName AS [Last Name],
	a.Balance AS [Current Balance],
	dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5) AS [Balance in 5 years]
	FROM Accounts AS a
	JOIN AccountHolders AS ah ON a.Id = ah.Id
	WHERE ah.Id = @AccountId
END

EXECUTE dbo.usp_CalculateFutureValueForAccount @AccountID = 1, @interestRate = 0.1