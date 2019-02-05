SELECT a.Name, a.Email, a.Bill, a.TownName
  FROM
(
SELECT Rank() OVER(PARTITION BY t.Id ORDER BY o.Bill DESC) AS Rank, 
       c.FirstName + ' ' + c.LastName AS Name, 
	   c.Email, 
	   o.Bill, 
	   t.Name AS TownName,
	   c.Id AS ClientId
  FROM Clients AS c
  JOIN Orders AS o
    ON o.ClientId = c.Id
  JOIN Towns AS t
    ON t.Id = o.TownId
 WHERE c.CardValidity < o.CollectionDate AND o.Bill IS NOT NULL
 ) AS a
 WHERE a.Rank IN (1, 2)
 ORDER BY a.TownName ASC, a.Bill ASC, a.ClientId ASC