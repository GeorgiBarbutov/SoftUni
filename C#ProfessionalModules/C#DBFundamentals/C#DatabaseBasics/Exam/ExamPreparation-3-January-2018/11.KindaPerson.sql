WITH CTE_ClientVechicleIdTimesOrdered
AS
(
SELECT c.FirstName + ' ' + c.LastName AS Name, o.VehicleId, COUNT(o.Id) AS TimesOrdered
  FROM Orders AS o
  JOIN Clients AS c
    ON c.Id = o.ClientId
GROUP BY c.FirstName + ' ' + c.LastName, o.VehicleId
),

CTE_NameClassOrderedTimes
AS
(
	SELECT cte.Name, m.Class, COUNT(m.Id) * MAX(cte.TimesOrdered) AS ModelTimesOrdered
  FROM CTE_ClientVechicleIdTimesOrdered AS cte
  JOIN Vehicles AS v
    ON v.Id = cte.VehicleId
  JOIN Models AS m
    ON m.Id = v.ModelId
GROUP BY cte.Name, m.Class
)

SELECT a.Name, cte.Class
  FROM
  (
SELECT cte.Name, MAX(cte.ModelTimesOrdered) AS MaxTimesOrdered
  FROM CTE_NameClassOrderedTimes AS cte
GROUP BY cte.Name
) AS a
  JOIN CTE_NameClassOrderedTimes AS cte
    ON cte.Name = a.Name AND cte.ModelTimesOrdered = a.MaxTimesOrdered
ORDER BY a.Name, cte.Class
