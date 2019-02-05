CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(8)
AS
BEGIN
	DECLARE @result VARCHAR(8)
	SET @result = 'High'

	IF(@salary < 30000)
	BEGIN
		SET @result = 'Low'
	END
	ELSE IF(@salary >= 30000 AND @salary <= 50000)
	BEGIN
		SET @result = 'Average'
	END

	RETURN @result
END
GO

SELECT Salary,
	   dbo.ufn_GetSalaryLevel(Salary)
  FROM Employees