WITH 
CTE_AccountTravelsPerCountry
AS
(
SELECT a.Id, c.CountryCode, COUNT(t.Id) AS TravelCount, ROW_NUMBER() OVER(PARTITION BY c.CountryCode ORDER BY COUNT(t.Id) DESC) AS Rank
  FROM Trips AS t
  JOIN Rooms AS r
    ON r.Id = t.RoomId
  JOIN Hotels AS h
    ON h.Id = r.HotelId
  JOIN Cities AS c
    ON c.Id = h.CityId
  JOIN AccountsTrips AS ac
    ON ac.TripId = t.Id
  JOIN Accounts AS a
    ON a.Id = ac.AccountId 
GROUP BY a.Id, c.CountryCode
)

SELECT a.Id, acc.Email, a.CountryCode, a.TravelCount
  FROM CTE_AccountTravelsPerCountry AS a
  JOIN Accounts AS acc
    ON acc.Id = a.Id
WHERE a.Rank = 1
ORDER BY a.TravelCount DESC, a.Id