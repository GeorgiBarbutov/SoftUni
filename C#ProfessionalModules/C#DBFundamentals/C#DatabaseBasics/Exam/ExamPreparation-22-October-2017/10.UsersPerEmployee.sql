    SELECT e.FirstName + ' ' + e.LastName AS [Name], COUNT(UserId) AS [User Number]
      FROM Employees AS e
LEFT OUTER JOIN Reports AS r
        ON r.EmployeeId = e.Id
  GROUP BY e.FirstName + ' ' + e.LastName
  ORDER BY [User Number] DESC, Name ASC