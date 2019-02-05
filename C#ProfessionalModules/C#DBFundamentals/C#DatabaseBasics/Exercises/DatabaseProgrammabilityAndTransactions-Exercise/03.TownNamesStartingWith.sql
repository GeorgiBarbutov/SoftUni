CREATE PROCEDURE usp_GetTownsStartingWith (@startingWith NVARCHAR(50))
AS
SELECT t.Name
  FROM Towns AS t
 WHERE t.Name LIKE @startingWith + '%'