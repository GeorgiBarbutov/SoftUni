    SELECT TOP(50) emp.EmployeeID, 
	       emp.FirstName + ' ' + emp.LastName AS [EmployeeName],
	       mgr.FirstName + ' ' + mgr.LastName AS [ManagerName], 
		   dpt.Name AS [DepartmentName]
      FROM Employees AS emp
LEFT OUTER JOIN Employees AS mgr
        ON emp.ManagerID = mgr.EmployeeID
INNER JOIN Departments AS dpt
        ON emp.DepartmentID = dpt.DepartmentID
  ORDER BY EmployeeID ASC