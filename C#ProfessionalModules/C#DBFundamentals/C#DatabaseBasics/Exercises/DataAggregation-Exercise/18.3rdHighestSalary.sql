SELECT DISTINCT t.DepartmentID, t.Salary
  FROM
       (
       SELECT e.DepartmentID, e.Salary,
              DENSE_RANK() OVER (PARTITION BY e.DepartmentID ORDER BY e.Salary DESC) AS [Rank]
       FROM Employees AS e
       ) AS t
 WHERE t.Rank = 3