SELECT TOP(50)
       [Name], 
	   CONCAT(YEAR([Start]), '-', MONTH([Start]) / 10, MONTH([Start]) % 10, '-', DAY([Start]) / 10, DAY([Start]) % 10) AS [Start]
  FROM Games
 WHERE YEAR([Start]) IN (2011, 2012)
 ORDER BY [Start], [Name]