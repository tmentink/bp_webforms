CREATE PROCEDURE [admin].[AddUser]
(
	@UserName NVARCHAR(50),
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@Email NVARCHAR(125),	
	@PasswordHash VARBINARY(255),
	@PasswordSalt NVARCHAR(50),
	@LastChangedBy INT,
	@UserID INT OUTPUT
)
AS BEGIN
	INSERT INTO [admin].Users (UserName, FirstName, LastName, Email, PasswordHash, PasswordSalt, LastChangedBy, LastChangedOn)
	SELECT @UserName, @FirstName, @LastName, @Email, @PasswordHash, @PasswordSalt, @LastChangedBy, GETDATE();
	
	SELECT @UserID = SCOPE_IDENTITY();
END