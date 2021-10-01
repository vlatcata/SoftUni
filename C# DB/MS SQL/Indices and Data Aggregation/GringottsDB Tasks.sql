SELECT COUNT(*) FROM WizzardDeposits

SELECT TOP(1) MagicWandSize FROM WizzardDeposits
ORDER BY MagicWandSize DESC

SELECT w.DepositGroup, MAX(w.MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits AS w
GROUP BY w.DepositGroup

SELECT TOP(2) w.DepositGroup
FROM WizzardDeposits AS w
GROUP BY w.DepositGroup
ORDER BY AVG(w.MagicWandSize)

SELECT w.DepositGroup, SUM(w.DepositAmount) AS TotalSum
FROM WizzardDeposits AS w
GROUP BY w.DepositGroup

SELECT w.DepositGroup, SUM(w.DepositAmount) AS TotalSum
FROM WizzardDeposits AS w
WHERE w.MagicWandCreator = 'Ollivander family'
GROUP BY w.DepositGroup

SELECT w.DepositGroup, SUM(w.DepositAmount) AS TotalSum
FROM WizzardDeposits AS w
WHERE w.MagicWandCreator = 'Ollivander family'
GROUP BY w.DepositGroup
HAVING SUM(w.DepositAmount) < 150000
ORDER BY TotalSum DESC

SELECT w.DepositGroup, w.MagicWandCreator, MIN(w.DepositCharge) AS MinDepositCharge
FROM WizzardDeposits AS w
GROUP BY w.DepositGroup, w.MagicWandCreator
ORDER BY w.MagicWandCreator, w.DepositGroup


SELECT AllAge AS AgeGroup, COUNT(*) AS WizardCount
FROM (SELECT CASE
				WHEN w.Age >= 0 AND w.Age <= 10 THEN '[0-10]'
				WHEN w.Age >= 11 AND w.Age <= 20 THEN '[11-20]'
				WHEN w.Age >= 21 AND w.Age <= 30 THEN '[21-30]'
				WHEN w.Age >= 31 AND w.Age <= 40 THEN '[31-40]'
				WHEN w.Age >= 41 AND w.Age <= 50 THEN '[41-50]'
				WHEN w.Age >= 51 AND w.Age <= 60 THEN '[51-60]'
				ELSE '[61+]'
		   END AS AllAge
	FROM WizzardDeposits AS w) AS DataAge
GROUP BY AllAge

SELECT FirstLetter
FROM (SELECT LEFT(w.FirstName, 1) as FirstLetter
	  FROM WizzardDeposits AS w
	  WHERE w.DepositGroup = 'Troll Chest') AS FirstLetters
GROUP BY FirstLetter

SELECT * FROM WizzardDeposits

SELECT w.DepositGroup, w.IsDepositExpired, AVG(w.DepositInterest) AS AverageInterest
FROM WizzardDeposits AS w
WHERE w.DepositStartDate > '01/01/1985'
GROUP BY w.DepositGroup, w.IsDepositExpired
ORDER BY w.DepositGroup DESC, w.IsDepositExpired ASC