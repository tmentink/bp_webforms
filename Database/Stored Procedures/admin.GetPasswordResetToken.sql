CREATE PROCEDURE [admin].[GetPasswordResetToken]
(	
	@Email NVARCHAR(125) = NULL,
	@UserName NVARCHAR(50) = NULL
)
AS BEGIN
	DECLARE @UserID INT
	DECLARE @FirstName NVARCHAR(50)
	SELECT @UserID = UserID, @Email = Email, @FirstName = FirstName
	FROM [admin].[Users]
	WHERE (@Email = Email AND @UserName IS NULL)
	   OR (@Email IS NULL AND @UserName = UserName)
	  AND IsLocked = 0;

	IF (@UserID IS NOT NULL)
		BEGIN
			DECLARE @RequestToken UNIQUEIDENTIFIER;
			SELECT @RequestToken = NEWID();

			DELETE
			FROM [admin].PasswordResetRequests
			WHERE UserID = @UserID;

			INSERT INTO [admin].PasswordResetRequests (RequestToken, UserID, Email, RequestDateTime)
			VALUES (@RequestToken, @UserID, @Email, GETDATE());
			
			SELECT @Email As Email, @FirstName AS FirstName, @RequestToken AS RequestToken;
		END
END