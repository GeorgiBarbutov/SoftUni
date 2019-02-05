    SELECT c.Name, r.ReportsNumber
      FROM (
		  SELECT r.CategoryId, COUNT(*) AS ReportsNumber
			FROM Reports AS r
		GROUP BY r.CategoryId) AS r
INNER JOIN Categories AS c
        ON c.Id = r.CategoryId
  ORDER BY r.ReportsNumber DESC, Name ASC