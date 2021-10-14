CREATE FUNCTION dbo.udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS INT
AS
BEGIN
	DECLARE @Result INT = (SELECT COUNT(c.Id)
							FROM Planets AS p
							JOIN Spaceports AS sp ON p.Id = sp.PlanetId
							JOIN Journeys AS j ON sp.Id = j.DestinationSpaceportId
							JOIN TravelCards AS tc ON j.Id = tc.JourneyId
							JOIN Colonists AS c ON tc.ColonistId = c.Id
							WHERE p.[Name] = @PlanetName)

	RETURN @Result
END

--SELECT dbo.udf_GetColonistsCount('Otroyphus')

GO


CREATE PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(11))
AS
BEGIN
	DECLARE @CurrentJorney INT = (SELECT Id
								  FROM Journeys
								  WHERE Id = @JourneyId)


	IF(@CurrentJorney IS NULL)
	THROW 50001, 'The journey does not exist!', 1

	DECLARE @CurrentJorneyPurpose VARCHAR(11) = (SELECT Purpose
												 FROM Journeys
												 WHERE Id = @CurrentJorney)


	IF(@CurrentJorneyPurpose = @NewPurpose)
	THROW 50001, 'You cannot change the purpose!', 1


	UPDATE Journeys
	SET Purpose = @NewPurpose
	WHERE Id = @CurrentJorney
	
END

--EXEC usp_ChangeJourneyPurpose 2, 'Educational'
--EXEC usp_ChangeJourneyPurpose 196, 'Technical'
--EXEC usp_ChangeJourneyPurpose 4, 'Technical'