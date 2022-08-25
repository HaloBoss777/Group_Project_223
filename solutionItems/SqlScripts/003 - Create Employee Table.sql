IF NOT EXISTS (SELECT *
FROM sysobjects
WHERE [Name] = 'Employee' AND xtype = 'U')
BEGIN

	CREATE TABLE [dbo].[Employee]
	(
		[Emp_Id] [int] IDENTITY(1,1) NOT NULL,
		[Full_Name] varchar(max) NOT NULL,
		[PO_BOX] varchar(max) NULL,
		[Street] varchar(max) NOT NULL,
		[Str_Num] int NOT NULL,
		[Area_Num] varchar(10) NOT NULL,
		[CellNum] varchar(13) NOT NULL,
		[Instructor] bit NOT NULL default 0,
		[Admin] bit NOT NULL default 0,
		[RSA_Id] varchar(13) NOT NULL,
		CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED
	(
		[Emp_Id] ASC
	)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]

	) ON [PRIMARY]


END