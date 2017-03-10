CREATE PROCEDURE [admin].[GetUserByUserName]
(
	@UserName NVARCHAR(50)
)
AS
BEGIN
	SELECT UserID, UserName, FirstName, LastName, Email, PasswordHash, PasswordSalt, IsLocked
	FROM [admin].[Users]
	WHERE UserName = @UserName;
END