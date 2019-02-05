CREATE TABLE Logs
(
	LogId INT IDENTITY NOT NULL,
	AccountId INT NOT NULL,
	OldSum DECIMAL(15, 2) NOT NULL,
	NewSum DECIMAL(15, 2) NOT NULL,

    CONSTRAINT PK_Logs
	PRIMARY KEY (LogId),
)
GO

CREATE TRIGGER tr_AccountsUpdate ON Accounts AFTER UPDATE
AS
	BEGIN TRANSACTION

	DECLARE @accountId INT =
		(SELECT Id FROM inserted)
	DECLARE @oldSum DECIMAL(15, 2) =
		(SELECT Balance FROM deleted)
	DECLARE @newSum DECIMAL(15, 2) =
		(SELECT Balance FROM inserted)

	INSERT INTO Logs VALUES
	(@accountId, @oldSum, @newSum)
