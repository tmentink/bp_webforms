CREATE PROCEDURE [admin].[AddErrorLog]
(
	@ErrorType NVARCHAR(50),
	@ErrorPage NVARCHAR(125),
	@UserID INT = NULL,
	@ErrorSource NVARCHAR(MAX) = NULL,
	@ErrorTarget NVARCHAR(MAX) = NULL,
	@ErrorMessage NVARCHAR(MAX) = NULL,
	@ErrorStackTrace NVARCHAR(MAX) = NULL,
	@Notes NVARCHAR(MAX) = NULL,
	@ErrorID INT OUTPUT
)
AS BEGIN
	INSERT INTO [admin].ErrorLog (ErrorDateTime, ErrorType, ErrorPage, UserID, ErrorSource, ErrorTarget, ErrorMessage, ErrorStackTrace, Notes)
	VALUES(GETDATE(), @ErrorType, @ErrorPage, @UserID, @ErrorSource, @ErrorTarget, @ErrorMessage, @ErrorStackTrace, @Notes);
	
	SELECT @ErrorID = SCOPE_IDENTITY();
END