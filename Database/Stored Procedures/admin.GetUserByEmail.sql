CREATE PROCEDURE [admin].[GetUserByEmail]
(
	@Email NVARCHAR(125)
)
AS
BEGIN
	SELECT UserID, UserName, FirstName, LastName, Email, PasswordHash, PasswordSalt, IsLocked
	FROM [admin].[Users]
	WHERE Email = @Email;
END