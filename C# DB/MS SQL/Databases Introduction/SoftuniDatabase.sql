CREATE DATABASE [SoftUni]

USE [SoftUni]

CREATE TABLE [Towns](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE [Addresses] (
	[Id] INT PRIMARY KEY IDENTITY,
	[AddressText] NVARCHAR(30) NOT NULL,
	[TownId] INT FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE [Departments] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL
)

CREATE TABLE [Employees] (
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(20) NOT NULL,
	[MiddleName] NVARCHAR(20) NOT NULL,
	[LastName] NVARCHAR(20) NOT NULL,
	[JobTitle] NVARCHAR(30) NOT NULL,
	[DepartmentId] INT FOREIGN KEY REFERENCES Departments(Id),
	[HireDate] DATE NOT NULL,
	[Salary] DECIMAL(7,2) NOT NULL,
	[AddressId] INT FOREIGN KEY REFERENCES Addresses(Id)
)


INSERT INTO [Towns] ([Name]) VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO [Departments] ([Name]) VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality'),
('Assurance')

INSERT INTO [Employees] ([FirstName], [MiddleName], [LastName], [JobTitle], [DepartmentId], [HireDate], [Salary]) VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013/01/02', 3500.00),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004/02/03', 4000.00),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016/08/28', 525.25),	
('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007/09/12', 3000.00),
('Peter', 'Pan', 'Pan', 'Internr', 3, '2016/08/28', 599.88)


SELECT * FROM [Towns]
SELECT * FROM [Departments]
SELECT * FROM [Employees]


SELECT * FROM [Towns] ORDER BY [Name] ASC
SELECT * FROM [Departments] ORDER BY [Name] ASC
SELECT * FROM [Employees] ORDER BY [Salary] DESC


SELECT [Name] FROM [Towns] ORDER BY [Name] ASC
SELECT [Name] FROM [Departments] ORDER BY [Name] ASC
SELECT [FirstName],[LastName],[JobTitle],[Salary] FROM [Employees] ORDER BY [Salary] DESC

UPDATE [Employees]
SET Salary = Salary * 1.10
SELECT [Salary] FROM [Employees]


