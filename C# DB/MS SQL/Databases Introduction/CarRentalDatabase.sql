CREATE DATABASE [CarRental]

USE [CarRental]

CREATE TABLE [Categories] (
	[Id] INT IDENTITY PRIMARY KEY,
	[CategoryName] NVARCHAR(100) NOT NULL,
	[DailyRate] DECIMAL(6,2) NOT NULL,
	[WeeklyRate] DECIMAL(6,2) NOT NULL,
	[MonthlyRate] DECIMAL(6,2) NOT NULL,
	[WeekendRate] DECIMAL(6,2) NOT NULL
)

CREATE TABLE [Cars] (
	[Id] INT PRIMARY KEY IDENTITY,
	[PlateNumber] NVARCHAR(10) UNIQUE NOT NULL,
	[Manufacturer] NVARCHAR(20) NOT NULL,
	[Model] NVARCHAR(20) NOT NULL,
	[CarYear] INT NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES Categories(Id),
	[Doors] INT NOT NULL,
	[Picture] VARBINARY(MAX),
	[Condition] NVARCHAR(30),
	[Available] BIT NOT NULL
)


CREATE TABLE [Employees] (
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(30) NOT NULL,
	[LastName] NVARCHAR(30) NOT NULL,
	[Title] NVARCHAR(40) NOT NULL,
	[Notes] NVARCHAR(200)
)

CREATE TABLE [Customers] (
	[Id] INT PRIMARY KEY IDENTITY,
	[DriverLicenseNumber] NVARCHAR(10) NOT NULL,
	[FullName] NVARCHAR(50) NOT NULL,
	[Adress] NVARCHAR(100) NOT NULL,
	[City] NVARCHAR(20) NOT NULL,
	[ZIPCode] NVARCHAR(20) NOT NULL,
	[Notes] NVARCHAR(200)
)


CREATE TABLE [RentalOrders] (
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES Employees(Id),
	[CustomerId] INT FOREIGN KEY REFERENCES Customers(Id),
	[CarId] INT FOREIGN KEY REFERENCES Cars(Id),
	[TankLevel] INT NOT NULL,
	[KilometrageStart] INT NOT NULL,
	[KilometrageEnd] INT NOT NULL,
	[TotalKilometrage] AS [KilometrageStart] - [KilometrageEnd],
	[StartDate] DATETIME2 NOT NULL,
	[EndDate] DATETIME2 NOT NULL,
	[TotalDays] AS DATEDIFF(Day, [StartDate], [EndDate]),
	[RateApplied] DECIMAL(6,2) NOT NULL,
	[TaxRate] DECIMAL(6,2) NOT NULL,
	[OrderStatus] NVARCHAR(30) NOT NULL,
	[Notes] NVARCHAR(MAX)
)


INSERT INTO [Categories] ([CategoryName], [DailyRate], [Weeklyrate], [MonthlyRate], [WeekendRate]) VALUES
('Coupe', 3.5, 5.5, 6.2, 8),
('Hatchback', 4.5, 7.5, 8, 9.2),
('Van', 2, 3.2, 4.2, 5.3)


INSERT INTO [Cars] ([PlateNumber], [Manufacturer], [Model], [CarYear], [CategoryId], [Doors], [Picture], [Condition], [Available]) VALUES
('6565HGGH3', 'Ford', 'Fiesta', 2007, 2, 3, NULL, 'Second Hand', 1),
('2534BG234', 'Ford', 'Fiesta', 2007, 2, 3, NULL, 'Second Hand', 0),
('335HMJ442', 'Ford', 'Fiesta', 2007, 2, 3, NULL, 'Second Hand', 1)


INSERT INTO [Employees] ([FirstName], [LastName], [Title], [Notes]) VALUES
('Ivan', 'Borisov', 'Engineer', 'I work very hard'),
('Georgi', 'Ivanov', 'Cleaner', 'I work very hard too'),
('Boris', 'Borisov', 'Manager', 'I dont really work')


INSERT INTO [Customers] ([DriverLicenseNumber], [FullName], [Adress], [City], [ZIPCode], [Notes]) VALUES
('10345618', 'Ivan Ivanov', 'Bulgaria', 'Sofia', '1404', 'none'),
('23892344', 'Ivan Borisov', 'Bulgaria', 'Varna', '1404', 'none'),
('32432456', 'Ivan Kvartalov', 'Bulgaria', 'Mars', '1404', 'none')

INSERT INTO [RentalOrders] ([EmployeeId], [CustomerId], [CarId], [TankLevel], [KilometrageStart], [KilometrageEnd], [StartDate], [EndDate], [RateApplied], [TaxRate], [OrderStatus], [Notes]) VALUES
(1, 1, 2, 70, 200, 300, '2020-05-02', '2020-05-04', 20.00, 10.00, 'TRUE', 'none'),
(2, 3, 3, 50, 0, 300, '2020-05-02', '2020-05-06', 25.00, 10.00, 'FALSE', 'none'),
(3, 2, 1, 10, 100, 500, '2020-05-02', '2020-06-04', 30.00, 10.00, 'TRUE', 'none')