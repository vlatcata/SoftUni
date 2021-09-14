CREATE DATABASE [Minions]

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
	[Id] BIGINT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX),
	CHECK (DATALENGTH([ProfilePicture]) <= 900000),
	[LastLoginTime] DATETIME2,
	[IsDeleted] BIT NOT NULL
)

ALTER TABLE [People]
DROP CONSTRAINT [PK__People__3214EC07F0275D16]

ALTER TABLE [People]
ADD CONSTRAINT [PK_UserCompositeIdUsername] PRIMARY KEY ([Id], [Username])
