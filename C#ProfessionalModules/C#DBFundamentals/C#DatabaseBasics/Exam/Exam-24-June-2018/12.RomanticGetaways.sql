WITH 
CTE_TripsPerPerson
AS
(
SELECT a.Id, COUNT(h.Id) AS Trips
  FROM Accounts AS a
  JOIN AccountsTrips AS att
    ON att.AccountId = a.Id
  JOIN Trips AS t
    ON t.Id = att.TripId
  JOIN Rooms AS r
    ON r.Id = t.RoomId
  JOIN Hotels AS h
    ON h.Id = r.HotelId
WHERE a.CityId = h.CityId
GROUP BY a.Id
)

SELECT a.Id, a.Email, c.Name, tpp.Trips
  FROM CTE_TripsPerPerson AS tpp
  JOIN Accounts AS a
    ON a.Id = tpp.Id
  JOIN Cities AS c
    ON c.Id = a.CityId
ORDER BY tpp.Trips DESC, a.Id