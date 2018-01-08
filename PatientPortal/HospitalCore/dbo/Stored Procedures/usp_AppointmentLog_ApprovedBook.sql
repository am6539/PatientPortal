CREATE PROC [dbo].[usp_AppointmentLog_ApprovedBook]
(
	@Id VARCHAR(MAX),
	@Status TINYINT = 1
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	DECLARE @return BIT = 1
	DECLARE @CreatedDate VARCHAR(20)
	DECLARE @ModifiedDate VARCHAR(20)

	BEGIN TRY
		BEGIN TRAN;
			-- Confirm accept
			IF @Status = 2
			BEGIN
				SET @ModifiedDate = [dbo].[ufnGetDate]()
				SET @CreatedDate = @ModifiedDate

				DECLARE @Ids VARCHAR(50)
				DECLARE IDs CURSOR FOR
				SELECT VALUE
				FROM   [dbo].[ufn_SpitString](@Id,',')
				OPEN IDs
				FETCH next FROM IDs INTO @Ids
				WHILE @@FETCH_STATUS = 0
				BEGIN

				--Get item by id
				SELECT * INTO #AppointmentLogById
				FROM [dbo].[AppointmentLog] l
				WHERE l.Id = @Ids

				--Post data to Appointment
				DECLARE @ColectionId INT
				INSERT [dbo].[Appointment]([PhysicianId], [PatientId], [Symptom], [CreatedDate], [ModifiedDate], [ModifedUser])
				SELECT item.PhysicianId, item.PatientId, item.Symptom, @CreatedDate, @ModifiedDate, N'Patient Test' FROM #AppointmentLogById item
				SET @ColectionId = (SELECT SCOPE_IDENTITY())

				--Generation Number
				SELECT TOP 1 s.AppointmentIntervalTime, s.AppointmentStartTime INTO #GenerationTime
				FROM [dbo].[Setting] s

				DECLARE @AppointmentNo INT
				DECLARE @IntervalTime INT
				DECLARE @StartTime INT
				DECLARE @Time INT

				SET @IntervalTime = (SELECT t.AppointmentIntervalTime FROM #GenerationTime t)
				SET @StartTime = (SELECT t.AppointmentStartTime FROM #GenerationTime t)
				SET @Time = (SELECT t.[Time] FROM [dbo].[AppointmentLog] t WHERE t.Id = @Ids )

				SET @AppointmentNo = [dbo].[ufnGenerationNumber](@Time, @IntervalTime, @StartTime)

				--Post data to AppointmentCollection
				INSERT [dbo].[AppointmentCollection]([Id], [Date], [Time], [AppointmentNo], [PatientName], [PatientAddress], [PatientEmail], [PatientPhone], [PatientGender], [PatientDoB], [Status])
				SELECT @ColectionId, item.[Date], item.[Time], @AppointmentNo, ISNULL(item.PatientName, N'NA'), ISNULL(item.PatientAddress, N'NA'), item.PatientEmail, item.PatientPhone, item.PatientGender, item.PatientDoB, 2 FROM #AppointmentLogById item

				UPDATE [dbo].[AppointmentLog] SET [Status] = 2 WHERE [Id] = @Ids

				-- DROP Temp Table
				DROP TABLE #AppointmentLogById
				DROP TABLE #GenerationTime

				
				FETCH next FROM IDs INTO @Ids
				END
				CLOSE IDs
				DEALLOCATE IDs

				SET @return = 1
			END

			-- Confirm cancel
			IF @Status = 3
			BEGIN
				DECLARE @isCheck BIT
				SET @isCheck = (SELECT TOP 1 s.IsSaveCanceledAppointment FROM [dbo].[Setting] s)
				IF @isCheck = 1
				BEGIN
					UPDATE [dbo].[AppointmentLog]
					SET [Status] = 3
					WHERE [Id] IN (@Id)

					SET @return = 1
				END
				ELSE
				BEGIN
					DELETE FROM [dbo].[AppointmentLog] WHERE [Id] IN (@Id)

					SET @return = 1
				END
			END
		COMMIT TRAN;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0 
		BEGIN
			ROLLBACK TRAN;
			SET  @return = 0
		END
	END CATCH
	SELECT @return;
END