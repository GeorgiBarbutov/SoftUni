SELECT TOP(10) e.FirstName, e.LastName, e.DepartmentID
  FROM Employees AS e
 WHERE e.Salary > 
       (
	   SELECT AVG(e2.Salary) AS [DepartmentAverageSalary] 
       FROM Employees AS e2
	   WHERE e.DepartmentID = e2.DepartmentID
       GROUP BY e2.DepartmentID
       )
 ORDER BY e.DepartmentID

