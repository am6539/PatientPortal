﻿CREATE FUNCTION [dbo].[ufnGetDate]()
RETURNS VARCHAR(20)
AS
BEGIN
	RETURN CONVERT(VARCHAR, GETDATE(), 103)
END
