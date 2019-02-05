CREATE PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN

	DECLARE @targetRoomHotelId INT = 
	(SELECT DISTINCT h.Id
	  FROM Trips AS t
	  JOIN Rooms AS r
	    ON r.Id = t.RoomId
	  JOIN Hotels AS h
	    ON h.Id = r.HotelId
	 WHERE r.Id = @TargetRoomId)

	 DECLARE @tripHotelId INT = 
	(SELECT DISTINCT h.Id
	  FROM Trips AS t
	  JOIN Rooms AS r
	    ON r.Id = t.RoomId
	  JOIN Hotels AS h
	    ON h.Id = r.HotelId
	 WHERE t.Id = @TripId)

	 IF(@targetRoomHotelId != @tripHotelId)
	 BEGIN
		RAISERROR('Target room is in another hotel!', 16, 1)
		RETURN
	 END

	 DECLARE @totalAccountForTrip INT =
	 (
		SELECT COUNT(*) 
		  FROM AccountsTrips AS ac
		 WHERE @TripId = ac.TripId
	 )
	 DECLARE @availableBeds INT =
	 (
		SELECT r.Beds
		  FROM Rooms AS r
		 WHERE r.Id = @TargetRoomId
	 )

	 IF(@availableBeds < @totalAccountForTrip)
	 BEGIN
		RAISERROR('Not enough beds in target room!', 16, 2)
		RETURN
	 END

	 UPDATE Trips
	 SET RoomId = @TargetRoomId
	 WHERE Id = @TripId
END


							 