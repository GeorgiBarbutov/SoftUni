CREATE PROCEDURE usp_DepositMoney (@accountId INT, @moneyAmount DECIMAL(15, 4))
AS
BEGIN
	BEGIN TRANSACTION

	IF(@moneyAmount <= 0)
	BEGIN
		ROLLBACK
		RETURN
	END

	UPDATE Accounts 
	   SET Balance += @moneyAmount
	 WHERE Id = @accountId

	 COMMIT
END