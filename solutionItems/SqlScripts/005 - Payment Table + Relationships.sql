IF NOT EXISTS (SELECT *
FROM sysobjects
WHERE [Name]='Payment' AND xtype='U')
BEGIN

	CREATE TABLE [dbo].[Payment]
	(
		[Payment_Id] [int] IDENTITY(1,1) NOT NULL,
		[Booking_Id] [int] NOT NULL,
		[Client_Id] [int] NOT NULL,
		[TotalPrice] Decimal(6,2) NOT NULL,
		[Paid] datetime NULL,

		CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[Payment_Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[Payment] WITH CHECK ADD CONSTRAINT [FK_Payment_Booking] FOREIGN KEY([Booking_Id])
REFERENCES [dbo].[Booking] ([Booking_Id])

	ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Booking]

	ALTER TABLE [dbo].[Payment] WITH CHECK ADD CONSTRAINT [FK_Payment_Client] FOREIGN KEY([Client_Id])
REFERENCES [dbo].[Client_Id] ([Client_Id])

	ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Client]

END