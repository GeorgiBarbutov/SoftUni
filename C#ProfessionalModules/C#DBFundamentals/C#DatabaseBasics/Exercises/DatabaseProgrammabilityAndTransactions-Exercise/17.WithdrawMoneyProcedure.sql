CREATE PROCEDURE usp_WithdrawMoney (@accountId INT, @moneyAmount DECIMAL (15, 4))
AS
BEGIN
	BEGIN TRANSACTION

	IF(@moneyAmount <= 0)
	BEGIN
		ROLLBACK
		RETURN
	END
	IF((SELECT Balance FROM Accounts WHERE @accountId = Id) < @moneyAmount)
	BEGIN
		ROLLBACK
		RETURN
	END

	UPDATE Accounts
	   SET Balance -= @moneyAmount
	 WHERE Id = @accountId

	 COMMIT
END