WITH
CTE_TripLuggageFee
AS
(
SELECT ac.TripId, SUM(ac.Luggage) AS Luggage, 
	CASE
		WHEN SUM(ac.Luggage) <= 5 THEN '$0'
		ELSE CONCAT('$', SUM(ac.Luggage) * 5)
	END AS Fee
  FROM Accounts AS a
  JOIN AccountsTrips AS ac
    ON ac.AccountId = a.Id
  JOIN Trips AS t
    ON t.Id = TripId
GROUP BY ac.TripId
HAVING SUM(ac.Luggage) > 0
)

SELECT *
FROM CTE_TripLuggageFee AS cte
ORDER BY cte.Luggage DESC
