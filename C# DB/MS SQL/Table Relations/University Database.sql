CREATE TABLE [Subjects](
	[SubjectID] INT PRIMARY KEY IDENTITY,
	[SubjectName] VARCHAR(30) NOT NULL
)

CREATE TABLE [Majors](
	[MajorID] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE [Students](
	[StudentID] INT PRIMARY KEY IDENTITY,
	[StudentNumber] INT NOT NULL,
	[StudentName] NVARCHAR(40) NOT NULL,
	[MajorID] INT REFERENCES [Majors]([MajorID])
)

CREATE TABLE [Payments](
	[PaymentID] INT PRIMARY KEY IDENTITY,
	[PaymentDate] DATE NOT NULL,
	[PaymentAmount] DECIMAL(5,2) NOT NULL,
	[StudentID] INT REFERENCES [Students]([StudentID])
)

CREATE TABLE [Agenda](
	[StudentID] INT REFERENCES [Students]([StudentID]),
	[SubjectID] INT REFERENCES [Subjects]([SubjectID]),
	PRIMARY KEY (StudentID, SubjectID)
)