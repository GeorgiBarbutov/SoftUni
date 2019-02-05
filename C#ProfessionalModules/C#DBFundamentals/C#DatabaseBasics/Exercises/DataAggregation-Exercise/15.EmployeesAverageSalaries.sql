SELECT *
  INTO EmployeesAverageSalary
  FROM Employees AS e
 WHERE e.Salary > 30000
GO

DELETE FROM EmployeesAverageSalary
WHERE ManagerID = 42
GO

UPDATE EmployeesAverageSalary
SET Salary += 5000
WHERE DepartmentID = 1
GO

SELECT eas.DepartmentID, AVG(eas.Salary)
  FROM EmployeesAverageSalary AS eas
 GROUP BY eas.DepartmentID
 GO
