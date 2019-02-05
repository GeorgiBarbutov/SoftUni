SELECT a.Manufacturer, a.AverageFuelConsumption
  FROM
  (
SELECT TOP(7) m.Model, m.Manufacturer, COUNT(o.Id) AS TimesOrdered, AVG(m.Consumption) AS AverageFuelConsumption
  FROM Orders AS o
  JOIN Vehicles AS v
    ON v.Id = o.VehicleId
  JOIN Models AS m
    ON m.Id = v.ModelId
 GROUP BY m.Model, m.Manufacturer
 ORDER BY TimesOrdered DESC
 ) AS a
 WHERE a.AverageFuelConsumption BETWEEN 5 AND 15
 ORDER BY a.Manufacturer, a.AverageFuelConsumption