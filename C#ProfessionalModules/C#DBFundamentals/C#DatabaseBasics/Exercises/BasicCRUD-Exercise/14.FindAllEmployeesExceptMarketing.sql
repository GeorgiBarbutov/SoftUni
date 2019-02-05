SELECT FirstName, LastName
  FROM Employees
 WHERE DepartmentID != (SELECT DepartmentID
						  FROM Departments
						 WHERE [Name] = 'Marketing')