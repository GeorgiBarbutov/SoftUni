  SELECT DISTINCT Username
    FROM Users AS u
    JOIN Reports AS r
      ON r.UserId = u.Id
   WHERE (LEFT(u.Username, 1) LIKE '[0-9]%' AND 
          LEFT(u.Username, 1) = CONVERT(VARCHAR ,r.CategoryId)) OR
	     (RIGHT(u.Username, 1) LIKE '[0-9]%' AND 
          RIGHT(u.Username, 1) = CONVERT(VARCHAR ,r.CategoryId))
ORDER BY Username