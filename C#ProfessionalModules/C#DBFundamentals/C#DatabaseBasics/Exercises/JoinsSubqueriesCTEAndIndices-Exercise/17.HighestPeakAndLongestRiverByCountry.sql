WITH CTE_LongestRiverPerCountry(CountryName, [LongestRiverLength])
AS
(
         SELECT c.CountryName, MAX(r.Length) AS [LongestRiverLength]
		   FROM Countries AS c
LEFT OUTER JOIN CountriesRivers AS cr
             ON cr.CountryCode = c.CountryCode
LEFT OUTER JOIN Rivers AS r
             ON r.Id = cr.RiverId
	   GROUP BY c.CountryName
),

CTE_HighestPeakPerCountry(CountryName, [HighestPeakElevation])
AS
(
         SELECT c.CountryName, MAX(p.Elevation) AS [HighestPeakElevation]
		   FROM Countries AS c
LEFT OUTER JOIN MountainsCountries AS mc
             ON mc.CountryCode = c.CountryCode
LEFT OUTER JOIN Mountains AS m
             ON m.Id = mc.MountainId
LEFT OUTER JOIN Peaks AS p
             ON p.MountainId = m.Id
	   GROUP BY c.CountryName
)

    SELECT TOP(5) p.CountryName, p.HighestPeakElevation, r.LongestRiverLength
      FROM CTE_HighestPeakPerCountry AS p
INNER JOIN CTE_LongestRiverPerCountry AS r
        ON p.CountryName = r.CountryName
  ORDER BY p.HighestPeakElevation DESC, r.LongestRiverLength DESC, p.CountryName ASC