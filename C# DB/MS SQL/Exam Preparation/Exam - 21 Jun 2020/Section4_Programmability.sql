GO

CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATETIME, @People INT)
RETURNS NVARCHAR(200)
AS
BEGIN

		DECLARE @RoomId INT = (SELECT TOP(1) R.Id 
							   FROM Trips AS T
								   JOIN Rooms  AS R ON R.Id = T.RoomId
								   JOIN Hotels AS H ON H.Id = R.HotelId
								   WHERE H.Id = @HotelId 
								   AND @Date NOT BETWEEN T.ArrivalDate AND T.ReturnDate
								   AND T.CancelDate IS NULL
								   AND R.Beds >= @People
								   AND YEAR(@Date) = YEAR(t.ArrivalDate)
								   ORDER BY R.Price DESC)

	IF(@RoomId IS NULL)
	RETURN 'No rooms available'

	
	DECLARE @HotelBaseRate DECIMAL(18,2) = (SELECT BaseRate FROM Hotels
						  WHERE Id = @HotelId)

	DECLARE @RoomType VARCHAR(20) = (SELECT [Type] FROM Rooms
									 WHERE Id = @RoomId)
	DECLARE @BedsCount INT = (SELECT Beds FROM Rooms
							  WHERE Id = @RoomId)

	DECLARE @RoomPrice DECIMAL(18,2) = (SELECT Price FROM Rooms
										WHERE Id = @RoomId)

	DECLARE @TotalPrice DECIMAL(18,2) = (@HotelBaseRate + @RoomPrice) * @People

	RETURN CONCAT('Room', ' ', @RoomId, ': ', @RoomType, ' (', @BedsCount, ' beds)', ' - $', @TotalPrice)
END

SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)
SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)

GO

CREATE PROCEDURE usp_SwitchRoom(@TripId INT , @TargetRoomId INT)
AS
BEGIN
	DECLARE @TripIdInHotel INT = (SELECT *
							FROM Trips AS T 
							JOIN Rooms AS R ON R.Id = T.RoomId
							JOIN Hotels AS H ON H.Id = R.HotelId
							WHERE T.Id = @TripId )

	DECLARE  @TargetRoomIdInHotel INT  = (SELECT H.Id
							FROM Rooms AS R
							JOIN Hotels AS H ON H.Id = R.HotelId
							WHERE R.Id = @TargetRoomId)

	IF(@TripIdInHotel != @TargetRoomIdInHotel)
	 THROW 50001, 'Target room is in another hotel!',1

	DECLARE  @BedsInTargetRoom INT  = (SELECT R.Beds
							FROM Rooms AS R
							WHERE R.Id = @TargetRoomIdInHotel)

	DECLARE  @CountOfTrips INT = (SELECT COUNT(AccountId)
                                      FROM AccountsTrips
                                      WHERE TripId = @TripId)

	IF(@BedsInTargetRoom < @CountOfTrips)
	 THROW 50002, 'Not enough beds in target room!',1

UPDATE Trips
SET RoomId=@TargetRoomId
WHERE Id = @TripId
END