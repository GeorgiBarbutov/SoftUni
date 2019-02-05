WITH CTE_CountryInfo(ContinentCode, CurrencyCode, CurrencyUsage)
AS
(
	  SELECT c.ContinentCode, c.CurrencyCode, COUNT(c.CurrencyCode) AS [CurrencyUsage]
        FROM Countries AS c
    GROUP BY c.ContinentCode, c.CurrencyCode
      HAVING COUNT(c.CurrencyCode) > 1
)

    SELECT t.ContinentCode, CTE_CountryInfo.CurrencyCode, t.CurrencyUsage
      FROM 
           (
	       SELECT ContinentCode, MAX(CurrencyUsage) AS [CurrencyUsage]
           FROM CTE_CountryInfo
           GROUP BY ContinentCode
	       ) AS t
INNER JOIN CTE_CountryInfo
        ON CTE_CountryInfo.ContinentCode = t.ContinentCode 
		   AND CTE_CountryInfo.CurrencyUsage = t.CurrencyUsage

