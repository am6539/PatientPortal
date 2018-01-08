CREATE FUNCTION [dbo].[ufnGenerationNumber](
	@Time INT,
	@IntervalTime INT,
	@StartTime INT
)
RETURNS INT
AS
BEGIN
	DECLARE @STT INT = 1
	WHILE (@StartTime+@IntervalTime <= @Time)
	BEGIN
		SET @STT = @STT + 1
		SET @StartTime = @StartTime + @IntervalTime
	END
	RETURN @STT
END
