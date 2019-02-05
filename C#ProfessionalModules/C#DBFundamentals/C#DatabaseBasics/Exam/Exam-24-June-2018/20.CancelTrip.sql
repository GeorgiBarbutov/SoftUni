CREATE TRIGGER TripDeleted ON Trips 
INSTEAD OF DELETE
AS
BEGIN
	UPDATE Trips
	SET CancelDate = GETDATE()
	WHERE Id IN
	(SELECT t.Id 
	  From Trips AS t
	  JOIN deleted AS d
	    ON t.Id = d.Id
	  WHERE d.CancelDate IS NULL
		)

END