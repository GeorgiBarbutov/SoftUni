CREATE PROCEDURE usp_GetHoldersFullName
AS
BEGIN
	SELECT ac.FirstName + ' ' + ac.LastName AS [Full Name]
	  FROM AccountHolders AS ac
END