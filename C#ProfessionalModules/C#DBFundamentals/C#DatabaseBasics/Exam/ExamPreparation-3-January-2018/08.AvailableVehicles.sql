SELECT m.Model, m.Seats, v.Mileage
  FROM Vehicles AS v
  JOIN Models AS m
    ON m.Id = v.ModelId
 WHERE v.Id NOT IN
 (SELECT o.VehicleId
   FROM Orders AS o
   WHERE o.ReturnDate IS NULL)
ORDER BY v.Mileage ASC, m.Seats DESC, m.Id ASC


SELECT *
  FROM Vehicles AS v
  LEFT JOIN Orders AS o
    ON o.VehicleId = v.Id