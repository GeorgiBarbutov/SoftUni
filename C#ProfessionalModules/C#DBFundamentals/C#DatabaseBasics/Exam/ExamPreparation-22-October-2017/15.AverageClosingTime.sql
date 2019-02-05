WITH CTE_ClosingTimePerReport
AS
(
	SELECT r.Id, DATEDIFF(DAY,r.OpenDate, r.CloseDate) AS [TimeForClosing]
	  FROM Reports AS r
	  JOIN Categories AS c
	    ON r.CategoryId = c.Id
	  JOIN Departments AS d
        ON d.Id = c.DepartmentId
)

SELECT d.Name, a.AverageClosingTime
  FROM
	 (SELECT d.Id AS [DepartmentId], ISNULL(CONVERT(VARCHAR, AVG(ct.TimeForClosing)), 'no info') AS [AverageClosingTime]
	    FROM Reports AS r
		JOIN Categories AS c
		  ON r.CategoryId = c.Id
		JOIN Departments AS d
		  ON d.Id = c.DepartmentId
		JOIN CTE_ClosingTimePerReport AS ct
          ON ct.Id = r.Id
	GROUP BY d.Id) AS a
  JOIN Departments AS d
    ON d.Id = a.DepartmentId
ORDER BY d.Name


