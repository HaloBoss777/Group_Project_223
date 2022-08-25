


IF NOT EXISTS (SELECT *
FROM sysobjects
WHERE [Name]='Client' AND xtype='U')
BEGIN

	CREATE TABLE [dbo].[Client]
	(
		[Client_Id] [int] IDENTITY(1,1) NOT NULL,
		[Name] varchar(255) NOT NULL,
		[Email] varchar(255) NOT NULL,
		[CellNum] varchar(13) NOT NULL,
		[RSA_ID] varchar(13) NOT NULL,
		CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Client_Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]

END