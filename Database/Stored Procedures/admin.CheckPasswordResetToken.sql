CREATE PROCEDURE [admin].[CheckPasswordResetToken]
(	
	@Token NVARCHAR(50),
	@IsValid INT OUTPUT
)
AS BEGIN
	DECLARE @AllowedDiff INT = 0;
	DECLARE @TimeDiff INT;
	SELECT @TimeDiff = DATEDIFF(DAY, RequestDateTime, GETDATE())
	FROM [admin].PasswordResetRequests
	WHERE CONVERT(NVARCHAR(50), RequestToken) = @Token;

	IF (@TimeDiff IS NULL OR @TimeDiff > @AllowedDiff)
		BEGIN
			SET @IsValid = 0;
		END
	ELSE
		BEGIN
			SET @IsValid = 1;
		END
END