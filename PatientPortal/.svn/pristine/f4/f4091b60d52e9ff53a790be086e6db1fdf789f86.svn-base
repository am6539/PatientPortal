CREATE PROCEDURE [dbo].[usp_OfferAdvise]
	@Id TINYINT,
	@PatientId NVARCHAR(128) = '',
	@Status BIT = 0
AS
	IF(@Id > 0)
	BEGIN
		SELECT * FROM [dbo].[OfferAdvise]
		WHERE [Id] = @Id
	END
	ELSE
	BEGIN
		IF (@PatientId <> '')
			SELECT * FROM [dbo].[OfferAdvise] WITH(INDEX(IX_OfferAdvise_PatientId)) WHERE [PatientId] = @PatientId ORDER BY [Id]
		ELSE
			SELECT * FROM [dbo].[OfferAdvise] WHERE [Status] = @Status ORDER BY [Id]
	END
RETURN 0