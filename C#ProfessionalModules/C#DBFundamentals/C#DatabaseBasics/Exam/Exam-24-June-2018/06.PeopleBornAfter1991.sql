SELECT 
	CASE 
		WHEN a.MiddleName IS NULL THEN a.FirstName + ' ' + a.LastName
		ELSE a.FirstName + ' ' + a.MiddleName + ' ' + a.LastName
	END,
	 YEAR(a.BirthDate)
  FROM Accounts AS a
 WHERE YEAR(a.BirthDate) > 1991
ORDER BY YEAR(a.BirthDate) DESC, a.FirstName ASC