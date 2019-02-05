SELECT t.Name, COUNT(o.Id) AS OfficesNumber
  FROM Offices AS o
  JOIN Towns AS t
    ON t.Id = o.TownId
GROUP BY t.Name
ORDER BY OfficesNumber DESC, t.Name ASC