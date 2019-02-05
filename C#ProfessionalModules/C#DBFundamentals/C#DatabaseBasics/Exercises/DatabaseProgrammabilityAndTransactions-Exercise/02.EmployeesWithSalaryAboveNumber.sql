CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber (@minSalary DECIMAL(18, 4))
AS
BEGIN
	SELECT e.FirstName, e.LastName
	  FROM Employees AS e
	 WHERE e.Salary >= @minSalary
END
