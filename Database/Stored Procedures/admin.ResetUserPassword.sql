CREATE PROCEDURE [admin].[ResetUserPassword]
(
	@Token NVARCHAR(50),	
	@PasswordHash VARBINARY(255),
	@PasswordSalt NVARCHAR(50)
)
AS BEGIN
	DECLARE @UserID INT;
	SELECT @UserID = UserID
	FROM [admin].PasswordResetRequests
	WHERE CONVERT(NVARCHAR(50), RequestToken) = @Token;
	
	UPDATE [admin].Users
	SET PasswordHash = @PasswordHash,
	    PasswordSalt = @PasswordSalt,
		LastChangedBy = @UserID,
		LastChangedOn = GETDATE()
	WHERE UserID = @UserID;

	DELETE
	FROM [admin].PasswordResetRequests
	WHERE CONVERT(NVARCHAR(50), RequestToken) = @Token;
END