CREATE TABLE NotificationEmails
(
	Id INT IDENTITY NOT NULL,
	Recipient INT NOT NULL,
	[Subject] NVARCHAR(MAX) NOT NULL,
	Body NVARCHAR(MAX) NOT NULL,

    CONSTRAINT PK_NotificationEmails
	PRIMARY KEY (Id)
)
GO

CREATE TRIGGER tr_LogsInserted ON Logs AFTER INSERT
AS
	DECLARE @recipient INT = 
		(SELECT AccountId FROM inserted)
	DECLARE @subject NVARCHAR(MAX) = CONCAT('Balance change for account: ', (SELECT AccountId FROM inserted))
	DECLARE @body NVARCHAR(MAX) = CONCAT('On ', GETDATE(), 
		' your balance was changed from ', (SELECT OldSum FROM inserted),
		' to ', (SELECT NewSum FROM inserted), '.')

	INSERT INTO NotificationEmails (Recipient, [Subject], Body)
	VALUES (@recipient, @subject, @body)
	GO
UPDATE Accounts
SET Balance += 100
WHERE Id = 1

SELECT * FROM Accounts WHERE Id  = 1