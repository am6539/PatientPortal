CREATE PROCEDURE [dbo].[usp_Login]
	@Email NVARCHAR(256),
	@PasswordHash VARCHAR(60)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRY
		SELECT u.Name, 
			g.Name as GroupName, 
			r.Name as RoleName,
			p.IsRead, 
			p.IsWrite, 
			p.IsCreate, 
			p.IsModify, 
			p.IsDestroy, 
			p.IsPrint
		FROM [dbo].Users u, [dbo].UserRole ur, [dbo].UserGroup ug,
		[dbo].[Role] r,[dbo].Permission p, [dbo].[Group] g, [dbo].Module m
		WHERE u.Email = @Email
		AND u.PasswordHash = @PasswordHash
		AND u.Id = ur.RoleId
		AND u.Id = ug.UserId
		AND ur.RoleId = r.Id
		AND ug.GroupId = g.Id
		AND r.Id = p.RoleId
		AND p.ModuleId = m.Id
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0
			BEGIN
				RETURN NULL
			END
	END CATCH
END
