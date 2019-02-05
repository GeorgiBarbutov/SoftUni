WITH
CTE_FemalesPerCity
AS
(
SELECT t.Name, c.Gender, COUNT(c.Id) AS FemaleCount
  FROM Orders AS o
  JOIN Towns AS t
    ON t.Id = o.TownId
  JOIN Clients AS c
    ON c.Id = o.ClientId
GROUP BY t.Name, c.Gender
HAVING c.Gender = 'F'
),

CTE_MalesPerCity
AS
(
SELECT t.Name, c.Gender, COUNT(c.Id) AS MaleCount
  FROM Orders AS o
  JOIN Towns AS t
    ON t.Id = o.TownId
  JOIN Clients AS c
    ON c.Id = o.ClientId
GROUP BY t.Name, c.Gender
HAVING c.Gender = 'M'
)

SELECT 
	CASE
		WHEN f.Name IS NULL THEN m.Name 
		WHEN m.Name IS NULL THEN f.Name
		ELSE f.Name 
	END AS TownName,
	CAST(m.MaleCount * 100.00 / (ISNULL(m.MaleCount, 0) + ISNULL(f.FemaleCount, 0)) AS INTEGER) AS MalePercent,
	CAST(f.FemaleCount * 100.00 / (ISNULL(m.MaleCount, 0) + ISNULL(f.FemaleCount, 0)) AS INTEGER) AS FemalePercent
  FROM CTE_FemalesPerCity AS f
  FULL JOIN CTE_MalesPerCity AS m
    ON m.Name = f.Name
	JOIN Towns AS t
	  ON t.Name = f.Name OR t.Name = m.Name
ORDER BY t.Name, t.Id