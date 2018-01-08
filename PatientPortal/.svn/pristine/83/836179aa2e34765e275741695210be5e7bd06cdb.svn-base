CREATE PROCEDURE [dbo].[usp_DefaultData_insert]
AS
begin
	declare @countRole int
	set @countRole = (select * from dbo.Role)
	if(@countRole = 0)
	begin
		insert into Role values('Role 1')
	end
end
go
