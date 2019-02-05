CREATE PROCEDURE usp_TransferMoney(@senderId INT, @receiverId INT, @amount DECIMAL(15, 4))
AS
BEGIN
	BEGIN TRANSACTION

	IF(@amount <= 0)
	BEGIN
		ROLLBACK
		RETURN
	END

	EXEC dbo.usp_WithdrawMoney @senderId, @amount
	EXEC dbo.usp_DepositMoney @receiverId, @amount

	COMMIT
END






