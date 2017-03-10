CREATE TABLE [admin].[PasswordResetRequests]
(
	[RequestToken] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [UserID] INT NOT NULL, 
    [Email] NVARCHAR(125) NOT NULL, 
    [RequestDateTime] DATETIME NOT NULL
)
