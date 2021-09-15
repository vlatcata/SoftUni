CREATE DATABASE [Minions]

CREATE DATABASE [Minions2]

USE [Minions2]

USE [Minions]

GO

CREATE TABLE [Minions](
	[Id] INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	[Age] INT
)

ALTER TABLE [Minions]
ADD CONSTRAINT PK_MinionsId PRIMARY KEY (Id)

DROP TABLE [Minions]

CREATE TABLE [Towns](
	[Id] INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
)

GO

ALTER TABLE [Minions]
ADD [TownId] INT


ALTER TABLE [Minions]
ADD CONSTRAINT [FK_MinionsTownId] FOREIGN KEY (TownId) REFERENCES [Towns]([Id])

INSERT INTO [Towns] ([Id], [Name]) VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO [Minions] ([Id], [Name], [Age], [TownId]) VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

TRUNCATE TABLE [Minions]


CREATE TABLE [People](
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX),
	CHECK (DATALENGTH([Picture]) <= 2000000),
	[Height] DECIMAL(10,2),
	[Weight] DECIMAL(10,2),
	[Gender] CHAR(1) NOT NULL,
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR(MAX)
)

INSERT INTO [People] ([Name], [Picture], [Height], [Weight], [Gender], [Birthdate], [Biography]) VALUES
('Ivan', NULL, 1.80, 80, 'm', '1998-02-12', 'mnogo sum gotin'),
('Boris', NULL, 1.82, 70, 'f', '2001-3-16', 'az sum po gotin'),
('Georgi', NULL, 1.50, 60, 'm', '2000-4-15', 'az sum nai gotin'),
('Petur', NULL, 1.60, 85, 'f', '2001-2-20', 'cringe'),
('Vasko', NULL, 1.73, 90, 'm', '2001-3-26', 'mlukni be brat')

CREATE TABLE [Users](
	[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
	[Username] VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX),
	CHECK (DATALENGTH([ProfilePicture]) <= 900000),
	[LastLoginTime] DATETIME2,
	[IsDeleted] BIT NOT NULL
)


INSERT INTO [Users] ([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted]) VALUES
('Ivankata', '123456', NULL, '1999-2-12', 0),
('Bobkata', '123456', NULL, '1992-2-2', 1),
('Kris2', '123456', NULL, '2001-2-12', 0),
('Petur123', '123456', NULL, '2003-2-12', 1),
('Gosho', '123456', NULL, '2013-2-12', 0)

ALTER TABLE [Users]
DROP CONSTRAINT [PK__Users__3214EC07B8B4664A]

ALTER TABLE [Users]
ADD CONSTRAINT [PK_UserCompositeIdUsername] PRIMARY KEY ([Id], [Username])

ALTER TABLE [Users]
ADD CONSTRAINT Check_Password_Length CHECK (LEN([Password])>=5)

ALTER TABLE [Users]
ADD CONSTRAINT Default_Value_LastLoginTime DEFAULT GETDATE() FOR [LastLoginTime]

INSERT INTO [Users] ([Username],[Password],[IsDeleted]) VALUES
('Vanq1GF','ASDa23a',0)

DELETE FROM Users WHERE Username='Vanq1GF'

ALTER TABLE [Users]
DROP CONSTRAINT [PK_UserCompositeIdUsername]

ALTER TABLE [Users]
ADD CONSTRAINT PK_Users_IdPrimaryKey PRIMARY KEY ([Id])

ALTER TABLE [Users]
ADD CONSTRAINT Check_Username_Length CHECK (LEN([Username])>=3)

SELECT * FROM [Users]
