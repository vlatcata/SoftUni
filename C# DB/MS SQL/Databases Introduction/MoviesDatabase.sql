CREATE DATABASE [Movies]

USE [Movies]

CREATE TABLE [Directors] (
	[Id] INT IDENTITY PRIMARY KEY,
	[DirectorName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(200)
)

CREATE TABLE [Genres] (
	[Id] INT IDENTITY PRIMARY KEY,
	[GenreName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(200)
)

CREATE TABLE [Categories] (
	[Id] INT IDENTITY PRIMARY KEY,
	[CategoryName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(200)
)

CREATE TABLE [Movies] (
	[Id] INT IDENTITY PRIMARY KEY,
	[Title] NVARCHAR(50) NOT NULL,
	[DirectorId] INT FOREIGN KEY REFERENCES Directors(Id),
	[CopyrightYear] INT NOT NULL,
	[Length] TIME NOT NULL,
	[GenreId] INT FOREIGN KEY REFERENCES Genres(Id),
	[CategoryId] INT FOREIGN KEY REFERENCES Categories(Id),
	[Rating] DECIMAL(3,1),
	[Notes] NVARCHAR(200)
)



INSERT INTO [Directors]([DirectorName], [Notes]) VALUES
('Pesho', NULL),
('Pesho2', NULL),
('Pesho3', NULL),
('Pesho4', NULL),
('Pesho5', NULL)

INSERT INTO [Genres]([GenreName], [Notes]) VALUES
('Action', NULL),
('Love', NULL),
('Sci-Fi', NULL),
('Scary', NULL),
('Racing', NULL)

INSERT INTO [Categories]([CategoryName], [Notes]) VALUES
('Category1', NULL),
('Category2', NULL),
('Category3', NULL),
('Category4', NULL),
('Category5', NULL)

INSERT INTO [Movies] ([Title], [DirectorId], [CopyrightYear], [Length], [GenreId], [CategoryId], [Rating], [Notes]) VALUES
('NFS1', 1, 2001, '1:30:00', 4, 2, 5.5, 'Cool movie'),
('NFS2', 3, 2003, '1:30:00', 3, 2, 5.5, 'Cool movie2'),
('NFS3', 2, 2005, '1:30:00', 5, 2, 5.5, 'Cool movie3'),
('NFS4', 1, 2010, '1:30:00', 4, 2, 5.5, 'Cool movie4'),
('NFS5', 5, 2015, '1:30:00', 2, 2, 5.5, 'Cool movie5')