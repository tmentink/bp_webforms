CREATE TABLE [admin].[Users]
(
	[UserID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserName] NVARCHAR(50) NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(125) NOT NULL, 
    [PasswordHash] VARBINARY(255) NOT NULL, 
    [PasswordSalt] NVARCHAR(50) NOT NULL, 
    [IsLocked] BIT NOT NULL DEFAULT 0, 
    [LastChangedBy] INT NOT NULL, 
    [LastChangedOn] DATETIME NOT NULL
)
