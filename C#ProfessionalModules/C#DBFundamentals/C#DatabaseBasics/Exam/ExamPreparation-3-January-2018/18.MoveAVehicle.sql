CREATE PROCEDURE usp_MoveVehicle(@vehicleId INT, @officeId INT)
AS
	BEGIN TRANSACTION

	DECLARE @carsInOffice INT = (SELECT COUNT(Id) FROM Vehicles WHERE OfficeId = @officeId)
	DECLARE @parkingPalces INT = (SELECT ParkingPlaces FROM Offices WHERE Id = @officeId)

	IF(@parkingPalces IS NULL OR @parkingPalces = 0 OR @parkingPalces - @carsInOffice <= 0)
	BEGIN
		RAISERROR ('Not enough room in this office!', 16, 1) 
		ROLLBACK
		RETURN
	END

	UPDATE Vehicles
	SET OfficeId = @officeId
	WHERE @vehicleId = Id

	COMMIT

