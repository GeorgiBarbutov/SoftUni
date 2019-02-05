    SELECT c.Name, COUNT(e.Id) AS [EmployeeNumber] 
      FROM Categories AS c
INNER JOIN Departments AS d
        ON d.Id = c.DepartmentId
INNER JOIN Employees AS e
        ON e.DepartmentId = d.Id
  GROUP BY c.Name 