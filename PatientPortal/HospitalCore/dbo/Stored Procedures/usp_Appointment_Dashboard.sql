CREATE PROC [dbo].[usp_Appointment_Dashboard]
	@UserId NVARCHAR(128)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRY
		SELECT TOP 5
			   a.[PhysicianId], b.[Name] AS [PhysicianName],
			   c.[Date] AS [Date], c.[Time] AS [Time], c.[AppointmentNo] AS [No],
			   e.[Name] AS [DepartmentName]
		FROM [dbo].[Appointment] a
			 LEFT JOIN [dbo].[Users] b ON a.[PhysicianId] = b.[Id]
			 LEFT JOIN [dbo].[AppointmentCollection] c ON a.[Id] = c.[Id]
			 LEFT JOIN [dbo].[DoctorProfile] d ON b.[Id] = d.[UserId]
			 LEFT JOIN [dbo].[Department] e ON d.[DepartmentId] = e.[Id]
		WHERE a.[PatientId] = @UserId ORDER BY c.[Date], c.[Time]  DESC
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0 
		BEGIN
			RETURN NULL
		END
	END CATCH
END