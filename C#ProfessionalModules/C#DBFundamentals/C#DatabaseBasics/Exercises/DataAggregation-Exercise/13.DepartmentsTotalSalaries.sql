SELECT e.DepartmentID, SUM(e.Salary)
  FROM Employees AS e
 GROUP BY e.DepartmentID
 ORDER BY e.DepartmentID