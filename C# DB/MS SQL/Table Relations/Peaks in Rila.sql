USE [Geography]


SELECT [MountainRange], Peaks.PeakName, Peaks.Elevation FROM [Mountains]
JOIN Peaks ON Peaks.MountainId = Mountains.ID AND MountainRange = 'Rila'
ORDER BY Elevation DESC