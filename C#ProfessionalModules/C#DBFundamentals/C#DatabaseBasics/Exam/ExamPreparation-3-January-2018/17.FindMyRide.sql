CREATE FUNCTION udf_CheckForVehicle(@townName NVARCHAR(50), @seatsNumber INT)
RETURNS NVARCHAR(50)
BEGIN
	DECLARE @result NVARCHAR(50) = (
	SELECT TOP(1) o.Name + ' - ' + m.Model
	  FROM Vehicles AS v
	  JOIN Offices AS o
	    ON o.Id = v.OfficeId
	  JOIN Towns AS t
	    ON t.Id = o.TownId
	  JOIN Models AS m
	    ON m.Id = v.ModelId
	 WHERE t.Name = @townName AND m.Seats = @seatsNumber
	ORDER BY o.Name ASC
	)

	IF(@result IS NULL)
	BEGIN
		RETURN 'NO SUCH VEHICLE FOUND'
	END

	RETURN @result
END 