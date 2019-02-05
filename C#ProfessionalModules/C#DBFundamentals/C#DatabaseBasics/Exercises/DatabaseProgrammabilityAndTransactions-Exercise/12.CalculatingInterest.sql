ALTER PROCEDURE usp_CalculateFutureValueForAccount (@accountId INT, 
                                                     @interestRate DECIMAL(15, 4))
AS
BEGIN
	 DECLARE @currentBalance DECIMAL(15, 2) = (SELECT a.Balance
											     FROM Accounts AS a
												WHERE a.Id = @accountId)

	 DECLARE @ballanceIn5Years DECIMAL(15, 3)
	 SET @ballanceIn5Years  = dbo.ufn_CalculateFutureValue (@currentBalance, 
														    @interestRate,
														    5)

	     SELECT a.Id AS [Account Id],
		        ah.FirstName,
				ah.LastName,
				@currentBalance AS [Current Balance],
				@ballanceIn5Years AS [Balance in 5 years]
	       FROM Accounts AS a
	 INNER JOIN AccountHolders AS ah
	         ON ah.Id = a.AccountHolderId
	      WHERE a.Id = @accountId
END
