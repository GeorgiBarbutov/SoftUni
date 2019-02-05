SELECT t.Id, 
	CASE 
		WHEN a.MiddleName IS NULL THEN a.FirstName + ' ' + a.LastName
		ELSE a.FirstName + ' ' + a.MiddleName + ' ' + a.LastName
	END AS FullName,
	(SELECT Name FROM Cities WHERE a.CityId = Id) AS CityName,
	(SELECT Name FROM Cities WHERE Id = h.CityId) AS HotelName,
	CASE
		WHEN t.CancelDate IS NULL THEN CAST(DATEDIFF(DAY, ArrivalDate, ReturnDate) AS NVARCHAR(20)) + ' days'
		ELSE 'Canceled'
	END
  FROM Trips AS t
  JOIN AccountsTrips AS ac
   ON ac.TripId = t.Id
  JOIN  Accounts AS a
    ON a.Id = ac.AccountId
  JOIN Rooms AS r
    ON r.Id = t.RoomId
  JOIN Hotels AS h
    ON h.Id = r.HotelId
ORDER BY FullName, t.Id