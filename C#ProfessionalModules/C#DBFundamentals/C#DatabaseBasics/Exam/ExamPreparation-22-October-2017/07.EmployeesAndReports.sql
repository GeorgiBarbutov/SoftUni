    SELECT e.FirstName, e.LastName, r.Description, FORMAT(r.OpenDate, 'yyyy-MM-dd') AS OpenDate
      FROM Reports AS r
INNER JOIN Employees AS e
        ON e.Id = r.EmployeeId
  ORDER BY r.EmployeeId ASC, OpenDate ASC, r.Id ASC