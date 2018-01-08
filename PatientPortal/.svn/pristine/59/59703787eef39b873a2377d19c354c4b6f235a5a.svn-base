CREATE PROC [dbo].[usp_Module_Initial]
( 
	@Group CHAR(1) = '1',
	@UserId NVARCHAR(128) = '',
	@DefaultRoleInitial NVARCHAR(256) = ''
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	--DEFAULT: 1 - CMS, 2 - Patient Services, 3 - Internal Services
	BEGIN TRY

		--CHECK ADMIN
		IF EXISTS(SELECT TOP 1 1 FROM [dbo].[Users] WHERE [Id] = @UserId AND  [IsAdmin] = 1)
		BEGIN
			SELECT * FROM [dbo].[Module] WHERE [Group] = @Group
		END
		ELSE
		BEGIN
			--CHECK USER IN ROLES
			IF EXISTS(SELECT TOP 1 1 FROM [dbo].[UserRole] a LEFT JOIN [dbo].[Role] b ON a.[RoleId] = b.[Id]
			WHERE [UserId] = @UserId AND b.[Name] = @DefaultRoleInitial)
			BEGIN
				SELECT * FROM [dbo].[Module] WHERE [Group] = @Group
			END
			ELSE
			BEGIN
				--GET ROLE 
				SELECT DISTINCT [PermissionId] INTO #PerRole FROM [dbo].[PermissionRoles] a LEFT JOIN (SELECT [RoleId] FROM [dbo].[UserRole] WHERE [UserId] = @UserId) b
				ON a.[RoleId] = b.[RoleId] 

				--GET PERMISSION
				SELECT CONVERT(NVARCHAR(256), SUBSTRING([Name],1,CHARINDEX('.', [Name])-1)) AS Handler INTO #Per FROM [dbo].[Permissions] a
				LEFT JOIN #PerRole b ON a.[Id] = b.[PermissionId]
				WHERE [Name] LIKE '%.Access%' 

				--CHECK DATA
				IF @@ROWCOUNT = 0
				BEGIN
					DROP TABLE #PerRole
					DROP TABLE #Per
					RETURN NULL
				END
		
				SELECT a.*  INTO #DraftModule FROM [dbo].[Module] a RIGHT JOIN #Per b ON a.[Handler] = b.[Handler] WHERE [Group] = @Group

				SELECT *  FROM [dbo].[Module] WHERE [Id] IN (SELECT [ParentId] FROM #DraftModule) AND [ParentId] = 0
				UNION ALL SELECT * FROM #DraftModule
				
				DROP TABLE #PerRole
				DROP TABLE #Per
				DROP TABLE #DraftModule
			END
		END
		
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0 
		BEGIN
			RETURN NULL
		END
	END CATCH
END