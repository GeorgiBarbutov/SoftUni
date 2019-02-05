SELECT DISTINCT c.Name
  FROM Reports AS r
  JOIN Users AS u
    ON u.Id = r.UserId
  JOIN Categories AS c
    ON c.Id = r.CategoryId
 WHERE DAY(u.BirthDate) = DAY(r.OpenDate) AND MONTH(u.BirthDate) = MONTH(r.OpenDate)