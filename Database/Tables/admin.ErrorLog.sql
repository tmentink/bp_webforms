CREATE TABLE [admin].[ErrorLog]
(
	[ErrorID] INT NOT NULL PRIMARY KEY IDENTITY(-1, -1),
	[ErrorDateTime] [datetime] NOT NULL DEFAULT GETDATE(),
	[ErrorType] [nvarchar](50) NOT NULL,
	[ErrorPage] [nvarchar](125) NOT NULL,
	[UserID] [int] NULL,
	[ErrorSource] [nvarchar](MAX) NULL,
	[ErrorTarget] [nvarchar](MAX) NULL,
	[ErrorMessage] [nvarchar](MAX) NULL,
	[ErrorStackTrace] [nvarchar](MAX) NULL,
	[Notes] [nvarchar](MAX) NULL,
)
