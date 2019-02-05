CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(50), @word NVARCHAR(50))
RETURNS BIT
AS
BEGIN
	DECLARE @i INT = 1;
	DECLARE @allLettersAreContained BIT = 1;

	WHILE (@i <= LEN(@word))
	BEGIN
		DECLARE @j INT = 1;	
		DECLARE @letterIsContained BIT = 0;

		WHILE (@j <= LEN(@setOfLetters))
		BEGIN
			IF(SUBSTRING(@word, @i, 1) = SUBSTRING(@setOfLetters, @j, 1))
			BEGIN
				SET @letterIsContained = 1;
			END

			IF(@letterIsContained = 1)
			BEGIN
				BREAK;
			END

			SET @j += 1;
		END

		IF(@letterIsContained = 0)
		BEGIN
			SET @allLettersAreContained = 0;
			BREAK;
		END

		SET @i += 1;
	END

	RETURN @allLettersAreContained;
END