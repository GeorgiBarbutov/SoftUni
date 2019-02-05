WITH 
CTE_MaxTripLength
AS
(
SELECT a.Id, MAX(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS MaxTripLength
  FROM Accounts AS a
  JOIN AccountsTrips AS acct
    ON acct.AccountId = a.Id
  JOIN Trips AS t
    ON t.Id = acct.TripId
GROUP BY a.Id
),

CTE_MinTripLength
AS
(
SELECT a.Id, Min(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS MinTripLength
  FROM Accounts AS a
  JOIN AccountsTrips AS acct
    ON acct.AccountId = a.Id
  JOIN Trips AS t
    ON t.Id = acct.TripId
GROUP BY a.Id
)

SELECT DISTINCT a.Id, a.FirstName + ' ' + a.LastName, maxt.MaxTripLength, mint.MinTripLength
  FROM Accounts AS a
  JOIN CTE_MaxTripLength AS maxt
    ON maxt.Id = a.Id
  JOIN CTE_MinTripLength AS mint
    ON mint.Id = a.Id
  JOIN AccountsTrips AS ac
    ON ac.AccountId = a.Id
  JOIN Trips AS t
    ON t.Id = ac.TripId
WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
ORDER BY maxt.MaxTripLength DESC, a.Id