CREATE PROC [dbo].[usp_AppointmentLog](
	@Id UniqueIdentifier
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	--cast(cast(0 as binary) as uniqueidentifier) convert zero to uniqueidentifier
	BEGIN TRY
		IF (@Id IS NOT NULL)
		BEGIN
			SELECT l.*,
				us.Name PhysicianName
				--un.Name PatientName,
			FROM [dbo].[AppointmentLog] l
				LEFT JOIN [dbo].[Users] us ON us.Id = l.PhysicianId
			WHERE l.Id = @Id
		END
		ELSE
		BEGIN
			SELECT l.*,
				us.Name PhysicianName
				--un.Name PatientName,
			FROM [dbo].[AppointmentLog] l
				LEFT JOIN [dbo].[Users] us ON us.Id = l.PhysicianId
		END
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0 
		BEGIN
			RETURN NULL
		END
	END CATCH
END