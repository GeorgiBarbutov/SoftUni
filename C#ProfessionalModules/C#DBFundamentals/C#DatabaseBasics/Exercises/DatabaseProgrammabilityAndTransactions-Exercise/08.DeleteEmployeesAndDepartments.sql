CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT NULL

	ALTER TABLE Departments
	DROP CONSTRAINT FK_Departments_Employees

	ALTER TABLE Employees
	DROP CONSTRAINT FK_Employees_Employees

	DELETE FROM Employees 
	WHERE DepartmentID = @departmentId
	
	DELETE FROM Departments 
	WHERE DepartmentID = @departmentId

	SELECT COUNT(*)
	FROM Employees
	WHERE DepartmentID = @departmentId
END

