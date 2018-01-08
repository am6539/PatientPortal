CREATE PROC [dbo].[usp_Appointment](
	@Id INT = 0,
	@Date DATE = '',
	@AppointmentNo INT = 0,
	@PatientName NVARCHAR(50) = ''
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRY
		IF (@Id > 0)
		BEGIN
			SELECT a.*,
				b.[Date], b.[Time], b.[AppointmentNo],
				b.[PatientName], b.[PatientAddress], b.[PatientEmail], b.[PatientPhone],
				b.[PatientGender], b.[PatientDoB], b.[Status]
			FROM [dbo].[Appointment] a  RIGHT JOIN [dbo].[AppointmentCollection] b 
			ON a.[Id] = b.[Id] WHERE a.[Id] = @Id
		END
		ELSE
		BEGIN
			DECLARE @SQLString NVARCHAR(500);
			DECLARE @ParmDefinition nvarchar(500); 

			SET @ParmDefinition = N'@Appointment_Date DATE, @Appointment_No INT,@Patient_Name NVARCHAR(50)';
			SET @SQLString = N'SELECT a.*,
				b.[Date], b.[Time], b.[AppointmentNo],
				b.[PatientName], b.[PatientAddress], b.[PatientEmail], b.[PatientPhone],
				b.[PatientGender], b.[PatientDoB], b.[Status]
			FROM [dbo].[Appointment] a  WITH(INDEX(idxAppointmentPhysician)) RIGHT JOIN [dbo].[AppointmentCollection] b 
			ON a.[Id] = b.[Id] WHERE b.[Date] = @Appointment_Date AND b.[AppointmentNo] = @Appointment_No';
			IF @PatientName != ''
				SET @SQLString = @SQLString + N' AND b.[PatientName]  LIKE N''%@Patient_Name%''';

			EXECUTE sp_executesql @SQLString, @ParmDefinition, @Appointment_Date = @Date, @Appointment_No = @AppointmentNo, @Patient_Name = @PatientName
		END
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0 
		BEGIN
			RETURN NULL
		END
	END CATCH
END