ALTER PROCEDURE usp_GetHoldersWithBalanceHigherThan (@number DECIMAL(15, 2))
AS
BEGIN
	SELECT ah.FirstName, ah.LastName
      FROM AccountHolders AS ah
INNER JOIN Accounts AS a
        ON ah.Id = a.AccountHolderId
  GROUP BY ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @number
END

EXEC dbo.usp_GetHoldersWithBalanceHigherThan 1000

    