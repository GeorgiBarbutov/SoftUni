 UPDATE Employees
    SET Salary *= 1.12
  WHERE DepartmentID IN 
(
(SELECT DepartmentId FROM Departments WHERE [Name] = 'Engineering'),
(SELECT DepartmentId FROM Departments WHERE [Name] = 'Tool Design'),
(SELECT DepartmentId FROM Departments WHERE [Name] = 'Marketing'),
(SELECT DepartmentId FROM Departments WHERE [Name] = 'Information Services')
)

SELECT Salary
  FROM Employees