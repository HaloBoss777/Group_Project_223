





IF NOT EXISTS (SELECT * FROM sysobjects WHERE [Name]='Activity' AND xtype='U')
BEGIN

CREATE TABLE [dbo].[Activity](
	[Activity_Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] varchar(255) NOT NULL,
	[Description] varchar(max) NOT NULL,
	[Price_PP] decimal(6,2) NOT NULL,
 CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED 
(
	[Activity_Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY] 
) ON [PRIMARY]

END