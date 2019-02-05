BEGIN TRANSACTION [LowLevelTransaction]
  
	DECLARE @userCash DECIMAL(15, 2) = (
		 SELECT ug.Cash
		   FROM Users AS u
		   JOIN UsersGames AS ug
		     ON ug.UserId = u.Id
		   JOIN Games AS g
		     ON g.Id = ug.GameId		
		  WHERE u.FirstName = 'Stamat' AND g.Name = 'Safflower'
		      )

	DECLARE @totalItemPrice DECIMAL(15, 2) = (
		SELECT SUM(i.Price)
		  FROM Items AS i
		 WHERE i.MinLevel IN (11, 12)
		 )

	IF(@userCash < @totalItemPrice)
	BEGIN
		ROLLBACK
		RETURN
	END

	UPDATE UsersGames
	   SET Cash -= @totalItemPrice
	 WHERE UserId = 9 AND GameId = 87

	DECLARE @userGameId INT = (
		SELECT ug.Id
 		  FROM Users AS u
		  JOIN UsersGames AS ug
			ON ug.UserId = u.Id
		  JOIN Games AS g
			ON g.Id = ug.GameId
		 WHERE u.FirstName = 'Stamat' AND g.Name = 'Safflower'
		 )

	INSERT INTO UserGameItems(UserGameId, ItemId)
	SELECT @userGameId, Id
	  FROM Items AS i
	 WHERE i.MinLevel IN (11, 12)

	 COMMIT TRANSACTION LowLevelTransaction

BEGIN TRANSACTION [HighevelTransaction]

	DECLARE @totalItemPrice2 DECIMAL(15, 2) = (
		SELECT SUM(i.Price)
		  FROM Items AS i
		 WHERE i.MinLevel IN (19, 20, 21)
		 )

	IF(@userCash < @totalItemPrice2)
	BEGIN
		ROLLBACK
		RETURN
	END

	UPDATE UsersGames
	   SET Cash -= @totalItemPrice2
	 WHERE UserId = 9 AND GameId = 87

	INSERT INTO UserGameItems(UserGameId, ItemId)
	SELECT @userGameId, Id
	  FROM Items AS i
	 WHERE i.MinLevel IN (19, 20, 21)

	COMMIT TRANSACTION [HighevelTransaction]

  SELECT i.Name AS [ItemName]
    FROM Users AS u
    JOIN UsersGames AS ug
      ON ug.UserId = u.Id
    JOIN Games AS g
      ON g.Id = ug.GameId
    JOIN UserGameItems AS ugi
      ON ugi.UserGameId = ug.Id
    JOIN Items AS i
      ON ugi.ItemId = i.Id
   WHERE u.FirstName = 'Stamat' AND g.Name = 'Safflower'
ORDER BY i.Name


