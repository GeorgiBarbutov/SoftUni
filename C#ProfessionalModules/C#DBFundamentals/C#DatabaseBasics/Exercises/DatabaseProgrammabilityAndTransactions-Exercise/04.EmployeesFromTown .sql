CREATE PROCEDURE usp_GetEmployeesFromTown (@townName NVARCHAR(50))
AS
BEGIN
		SELECT e.FirstName, e.LastName
		  FROM Employees AS e
	INNER JOIN Addresses AS a
			ON a.AddressID = e.AddressID
	INNER JOIN Towns AS t
			ON t.TownID = a.TownID
		 WHERE t.Name = @townName
END
    
EXEC dbo.usp_GetEmployeesFromTown 'Sofia'
