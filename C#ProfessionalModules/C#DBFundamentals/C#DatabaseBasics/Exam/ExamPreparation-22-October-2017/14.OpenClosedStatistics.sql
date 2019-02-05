WITH CTE_ClosedReports
AS
(
SELECT e.FirstName + ' ' + e.LastName AS [Name], COUNT(r.CloseDate) AS [ClosedReports]
  FROM Employees AS e
INNER JOIN Reports AS r
        ON r.EmployeeId = e.Id
	 WHERE YEAR(r.CloseDate) = 2016
  GROUP BY e.FirstName + ' ' + e.LastName
),

CTE_OpenReports
AS
(
SELECT e.FirstName + ' ' + e.LastName AS [Name], COUNT(r.OpenDate) AS [OpenReports]
  FROM Employees AS e
INNER JOIN Reports AS r
        ON r.EmployeeId = e.Id
	 WHERE YEAR(r.OpenDate) = 2016
  GROUP BY e.FirstName + ' ' + e.LastName
)

SELECT 
	CASE 
		WHEN cr.Name IS NOT NULL AND openR.Name IS NOT NULL THEN openR.Name
		WHEN cr.Name IS NULL AND openR.Name IS NOT NULL THEN openR.Name
	    WHEN openR.NAME IS NULL AND cr.Name IS NOT NULL THEN cr.NAME
	END AS [Name],
	CASE 
		WHEN cr.ClosedReports IS NOT NULL AND openR.OpenReports IS NOT NULL THEN CONCAT(cr.ClosedReports, '/', openR.OpenReports)
		WHEN cr.ClosedReports IS NULL AND openR.OpenReports IS NOT NULL THEN CONCAT('0/', openR.OpenReports)
	    WHEN openR.OpenReports IS NULL AND cr.ClosedReports IS NOT NULL THEN CONCAT(cr.ClosedReports, '/0')
	END AS [Closed OpenReports]
  FROM CTE_ClosedReports AS cr
FULL OUTER JOIN CTE_OpenReports AS openR
             ON cr.Name = openR.Name


