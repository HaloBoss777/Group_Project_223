


IF NOT EXISTS (SELECT *
FROM sysobjects
WHERE [Name] = 'Equipment' AND xtype = 'U')
BEGIN

	CREATE TABLE [dbo].[Equipment]
	(
		[Equipment_Id] [int] IDENTITY(1,1) NOT NULL,
		[Name] varchar(max) NOT NULL,
		[Broken] bit NOT NULL default 0,
		CONSTRAINT [PK_Equipment] PRIMARY KEY CLUSTERED
	(
		[Equipment_Id] ASC
	)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]

	) ON [PRIMARY]


END