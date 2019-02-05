SELECT a.FirstName, a.LastName, FORMAT(a.BirthDate, 'MM-dd-yyyy'), c.Name, a.Email
  FROM Accounts AS a
  JOIN Cities AS c
    ON c.Id = a.CityId
 WHERE LEFT(a.Email, 1) = 'e'
ORDER BY c.Name DESC