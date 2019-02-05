CREATE TRIGGER TR_AddTotalMileage ON Orders AFTER UPDATE
AS
BEGIN
	
     DECLARE @oldMileage INT = 
	 (SELECT TotalMileage FROM deleted)
	 DECLARE @newMileage INT = 
	 (SELECT TotalMileage FROM inserted)
	 DECLARE @vehicleId INT =
	 (SELECT vehicleId FROM inserted)

	 IF (@oldMileage IS NULL AND @vehicleId IS NOT NULL)
	 BEGIN
		UPDATE Vehicles
		SET Mileage += @newMileage
		WHERE Id = 	 (SELECT vehicleId FROM inserted)
	 END
END

UPDATE Orders
SET
TotalMileage = 100
WHERE Id = 40;
