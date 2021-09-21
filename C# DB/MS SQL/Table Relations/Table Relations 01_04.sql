-- 01.One-To-One Relationship

CREATE TABLE [Passports](
	[PassportID] INT PRIMARY KEY IDENTITY,
	[PassportNumber] NVARCHAR(20)
)

CREATE TABLE [Persons](
	[PersonID] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(20) NOT NULL,
	[Salary] DECIMAL(7,2) NOT NULL,
	[PassportID] INT UNIQUE FOREIGN KEY REFERENCES [Passports]([PassportID])
)

INSERT INTO [Passports] ([PassportNumber]) VALUES
('N34FG21B'),
('K65LO4R7'),
('ZE657QP2')

INSERT INTO [Persons] ([FirstName], [Salary], [PassportID]) VALUES
('Roberto', 43300.00, 2),
('Tom', 56100.00, 3),
('Yana', 60200.00, 1)



-- 02.One-To-Many Relationship

CREATE TABLE [Manufacturers] (
	[ManufacturerID] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	[EstablishedOn] DATE
)

CREATE TABLE [Models](
	[ModelID] INT PRIMARY KEY IDENTITY(101,1),
	[Name] NVARCHAR(20) NOT NULL,
	[ManufacturerID] INT FOREIGN KEY REFERENCES [Manufacturers]([ManufacturerID])
)

INSERT INTO [Manufacturers]([Name], [EstablishedOn]) VALUES
('BMW', '1916-03-07'),
('Tesla', '2003-01-01'),
('Lada', '1966-05-01')

INSERT INTO [Models]([Name], [ManufacturerID]) VALUES
('X1', 1),
('i6', 1),
('Model S', 2),
('Model X', 2),
('Model 3', 2),
('Nova', 3)



-- 03.Many-To-Many Relationship

CREATE TABLE [Students](
	[StudentID] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE [Exams](
	[ExamID] INT PRIMARY KEY IDENTITY(101, 1),
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE [StudentsExams](
	[StudentID] INT REFERENCES [Students]([StudentID]),
	[ExamID] INT REFERENCES [Exams]([ExamID]),
	PRIMARY KEY (StudentID, ExamID)
)

INSERT INTO [Students]([Name]) VALUES
('Mila'),
('Toni'),
('Ron')

INSERT INTO [Exams]([Name]) VALUES
('SpringMVC'),
('Neo4j'),
('Oracle 11g')

INSERT INTO [StudentsExams] VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)



-- 	Self-Referencing

CREATE TABLE [Teachers](
	[TeacherID] INT PRIMARY KEY IDENTITY(101, 1),
	[Name] NVARCHAR (50) NOT NULL,
	[ManagerID] INT FOREIGN KEY REFERENCES [Teachers]([TeacherID])
)

INSERT INTO [Teachers]([Name], [ManagerID]) VALUES
('John', NULL),
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101)