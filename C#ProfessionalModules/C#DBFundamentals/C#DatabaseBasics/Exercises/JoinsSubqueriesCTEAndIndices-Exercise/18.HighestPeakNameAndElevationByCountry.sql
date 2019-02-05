WITH CTE_HighestPeakPerCountry(CountryName, HighestPeakElevation)
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
),

CTE_PeaksAndMountainsPerCountry(CountryName, PeakName, MountainRange, Elevation)
AS
(
		 SELECT c.CountryName, 
			    p.PeakName, 
				m.MountainRange,
				p.Elevation
		   FROM Countries AS c
LEFT OUTER JOIN MountainsCountries AS mc
             ON mc.CountryCode = c.CountryCode
LEFT OUTER JOIN Mountains AS m
             ON m.Id = mc.MountainId
LEFT OUTER JOIN Peaks AS p
             ON p.MountainId = m.Id
)

         SELECT TOP(5) hp.CountryName,
		        CASE
					WHEN pm.PeakName IS NULL THEN '(no highest peak)'
					ELSE pm.PeakName
				END AS [Highest Peak Name],
				CASE
					WHEN hp.HighestPeakElevation IS NULL THEN 0
					ELSE hp.HighestPeakElevation
				END AS [Highest Peak Elevation],
				CASE
					WHEN pm.MountainRange IS NULL THEN '(no mountain)'
					ELSE pm.MountainRange
				END AS [Mountain]
           FROM CTE_HighestPeakPerCountry AS hp
LEFT OUTER JOIN CTE_PeaksAndMountainsPerCountry AS pm
             ON pm.CountryName = hp.CountryName
			    AND pm.Elevation = hp.HighestPeakElevation
	   ORDER BY hp.CountryName, pm.PeakName