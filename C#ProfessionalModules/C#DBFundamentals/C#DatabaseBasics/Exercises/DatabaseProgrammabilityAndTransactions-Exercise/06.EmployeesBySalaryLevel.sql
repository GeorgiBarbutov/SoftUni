Alter PROCEDURE usp_EmployeesBySalaryLevel (@levelOfSalary VARCHAR(8))
AS
BEGIN
	SELECT FirstName, LastName
	  FROM Employees		
	 WHERE dbo.ufn_GetSalaryLevel(Salary) = @levelOfSalary
END

EXEC dbo.usp_EmployeesBySalaryLevel 'Average'