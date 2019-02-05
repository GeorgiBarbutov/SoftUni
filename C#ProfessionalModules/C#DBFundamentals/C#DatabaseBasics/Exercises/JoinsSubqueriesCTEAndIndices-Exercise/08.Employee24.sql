    SELECT e.EmployeeID, 
           e.FirstName,
		   CASE
			  WHEN p.StartDate > '2004.12.31' THEN NULL
	  	      ELSE p.Name
           END AS [ProjectName]
	  FROM Employees AS e
INNER JOIN EmployeesProjects AS ep
        ON ep.EmployeeID = e.EmployeeID AND e.EmployeeID = 24
INNER JOIN Projects AS p
        ON p.ProjectID = ep.ProjectID