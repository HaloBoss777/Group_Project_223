




IF NOT EXISTS (SELECT * FROM sysobjects WHERE [Name]='Booking' AND xtype='U')
BEGIN

CREATE TABLE [dbo].[Booking](
	[Booking_Id] [int] IDENTITY(1,1) NOT NULL,
	[Client_Id] [int] NOT NULL,
	[Activity_Id] [int] NOT NULL,
	[Emp_Id] [int] NOT NULL,
	[Payment_Id] [int] NULL,
	[Date_Booked] datetime NOT NULL,
	[Attendees] int NOT NULL default 0,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[Booking_Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY] 
) ON [PRIMARY]

ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Client] FOREIGN KEY([Client_Id])
REFERENCES [dbo].[Client] ([Client_Id])

ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Client]


ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Activity] FOREIGN KEY([Activity_Id])
REFERENCES [dbo].[Activity] ([Activity_Id])

ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Activity]


ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Employee] FOREIGN KEY([Emp_Id])
REFERENCES [dbo].[Employee] ([Emp_Id])

ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Employee]

END