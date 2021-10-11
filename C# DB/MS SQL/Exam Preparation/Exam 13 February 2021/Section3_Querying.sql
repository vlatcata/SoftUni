SELECT Id, [Message], RepositoryId, ContributorId
FROM Commits
ORDER BY Id, [Message], RepositoryId, ContributorId

SELECT f.Id, f.[Name], f.Size
FROM Files AS f
WHERE f.Size > 1000 AND f.[Name] LIKE '%html'
ORDER BY f.Size DESC, f.Id, f.[Name]

SELECT i.Id, CONCAT(u.Username, ' : ', i.Title) AS [IssueAssignee]
FROM Issues AS i
LEFT JOIN Users AS u ON i.AssigneeId = u.Id
ORDER BY i.Id DESC, IssueAssignee

SELECT f.Id, f.[Name], CONCAT(f.Size, 'KB') AS [Size]
FROM Files AS f
LEFT JOIN Files AS fl ON f.Id = fl.ParentId
WHERE fl.ParentId IS NULL
ORDER BY f.Id, f.[Name], f.Size DESC

SELECT TOP(5) r.Id, r.[Name], COUNT(*) as [Commits]
FROM Repositories AS r
LEFT JOIN Commits AS c ON r.Id = c.RepositoryId
LEFT JOIN RepositoriesContributors AS rc ON r.Id = rc.RepositoryId
GROUP BY r.[Id], r.[Name]
ORDER BY Commits DESC, r.Id, r.[Name]

SELECT u.Username, AVG(f.Size) AS [Size]
FROM Users AS u
JOIN Commits AS c ON u.Id = c.ContributorId
JOIN Files AS f ON c.Id = f.CommitId
GROUP BY u.Username
ORDER BY Size DESC, u.Username