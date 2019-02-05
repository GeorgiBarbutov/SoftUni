CREATE FUNCTION udf_GetAvailableRoom(@hotelId INT, @date DATE, @people INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @hotelBaseRate DECIMAL(15, 2) = 
	(SELECT BaseRate FROM Hotels WHERE Id = @hotelId)

	DECLARE @roomId INT = 
		(SELECT TOP(1) r.Id
		  FROM Rooms AS r
		  JOIN Hotels AS h
			ON h.Id = r.HotelId
		 WHERE h.Id = @hotelId AND 
			   r.Beds >= @people AND
			   r.Id NOT IN (SELECT t.RoomId 
							  FROM Trips AS t
							  JOIN Rooms AS r
					     		ON r.Id = t.RoomId
							  JOIN Hotels AS h
					     		ON h.Id = r.HotelId
							 WHERE h.Id = @hotelId AND ((@date BETWEEN t.ArrivalDate AND t.ReturnDate) OR t.CancelDate IS NOT NULL)
							 )
		 ORDER BY (h.BaseRate + r.Price) * @people DESC
		 )
	DECLARE @roomtype NVARCHAR(50) = 
	(SELECT TOP(1) r.Type
		  FROM Rooms AS r
		  JOIN Hotels AS h
			ON h.Id = r.HotelId
		 WHERE h.Id = @hotelId AND 
			   r.Beds >= @people AND
			   r.Id NOT IN (SELECT t.RoomId 
							  FROM Trips AS t
							  JOIN Rooms AS r
					     		ON r.Id = t.RoomId
							  JOIN Hotels AS h
					     		ON h.Id = r.HotelId
							 WHERE h.Id = @hotelId AND ((@date BETWEEN t.ArrivalDate AND t.ReturnDate) OR t.CancelDate IS NOT NULL)
							 )
		 ORDER BY (h.BaseRate + r.Price) * @people DESC 
		 )
		 DECLARE @roomBeds INT = 
	(SELECT TOP(1)r.Beds--, (h.BaseRate + r.Price) * @people AS TotalPrice
		  FROM Rooms AS r
		  JOIN Hotels AS h
			ON h.Id = r.HotelId
		 WHERE h.Id = @hotelId AND 
			   r.Beds >= @people AND
			   r.Id NOT IN (SELECT t.RoomId 
							  FROM Trips AS t
							  JOIN Rooms AS r
					     		ON r.Id = t.RoomId
							  JOIN Hotels AS h
					     		ON h.Id = r.HotelId
							 WHERE h.Id = @hotelId AND ((@date BETWEEN t.ArrivalDate AND t.ReturnDate) OR t.CancelDate IS NOT NULL)
							 )
		 ORDER BY (h.BaseRate + r.Price) * @people DESC
		 )
		 DECLARE @roomTotalPrice DECIMAL(15, 2) = 
	(SELECT TOP(1) (h.BaseRate + r.Price) * @people
		  FROM Rooms AS r
		  JOIN Hotels AS h
			ON h.Id = r.HotelId
		 WHERE h.Id = @hotelId AND 
			   r.Beds >= @people AND
			   r.Id NOT IN (SELECT t.RoomId 
							  FROM Trips AS t
							  JOIN Rooms AS r
					     		ON r.Id = t.RoomId
							  JOIN Hotels AS h
					     		ON h.Id = r.HotelId
							 WHERE h.Id = @hotelId AND ((@date BETWEEN t.ArrivalDate AND t.ReturnDate) OR t.CancelDate IS NOT NULL)
							 )
		 ORDER BY (h.BaseRate + r.Price) * @people DESC
		 )

		 IF(@roomId IS NULL)
		 BEGIN 
			RETURN 'No rooms available'
		 END
		 RETURN CONCAT('Room ', @roomId, ': ', @roomtype, ' (', @roomBeds, ' beds) - $', @roomTotalPrice)
END 