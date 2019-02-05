WITH
CTE_CarLocations
AS
(
	SELECT m.Manufacturer + ' - ' + m.Model AS Vechicle, 
		CASE
			WHEN o.Id IS NULL THEN 'home'
			WHEN o.ReturnOfficeId IS NOT NULL AND v.OfficeId != o.ReturnOfficeId THEN t.Name + ' - ' + office.Name
			WHEN o.CollectionDate IS NOT NULL AND o.ReturnDate IS NULL THEN 'on a rent'
		END AS Location,
		   ROW_NUMBER() OVER (PARTITION BY v.Id ORDER BY CollectionDate) AS LocationNumber,
	       v.Id AS Id
	  FROM Vehicles AS v
 LEFT JOIN Orders AS o
        ON o.VehicleId = v.Id
 LEFT JOIN Models AS m
	    ON m.Id = v.ModelId
 LEFT JOIN Offices AS office
		ON office.Id = o.ReturnOfficeId
 LEFT JOIN Towns AS t
		ON t.Id = office.TownId
)

  SELECT cl2.Vechicle, cl2.Location
    FROM
	(
	  SELECT cl.Id, MAX(LocationNumber) AS LastLocation
	    FROM CTE_CarLocations AS cl		
	GROUP BY cl.Id
	) AS a
	JOIN CTE_CarLocations AS cl2
	  ON cl2.Id = a.Id
   WHERE a.LastLocation = cl2.LocationNumber
ORDER BY cl2.Vechicle, cl2.Id