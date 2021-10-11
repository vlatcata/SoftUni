CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @Result INT

	SET @Result = (SELECT COUNT(*)
				   FROM Users AS u
				   JOIN Commits AS c ON u.Id = c.ContributorId
				   WHERE u.Username = @username)

	RETURN @Result
END

SELECT dbo.udf_AllUserCommits('UnderSinduxrein')

GO

CREATE PROCEDURE usp_SearchForFiles(@fileExtension VARCHAR(6))
AS
BEGIN
	SELECT f.Id, f.[Name], CONCAT(f.Size, 'KB') AS Size
	FROM Files AS f
	WHERE RIGHT(f.[Name], LEN(@fileExtension)) = @fileExtension
END

EXEC usp_SearchForFiles 'txt'