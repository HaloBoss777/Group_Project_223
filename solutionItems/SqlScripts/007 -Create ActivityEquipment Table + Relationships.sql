




IF NOT EXISTS (SELECT * FROM sysobjects WHERE [Name]='ActivityEquipment' AND xtype='U')
BEGIN

CREATE TABLE [dbo].[ActivityEquipment](
	[ActivityEquipment_Id] [int] IDENTITY(1,1) NOT NULL,
	[Activity_Id] [int] NOT NULL,
	[Equipment_Id] [int] NOT NULL,
 CONSTRAINT [PK_ActivityEquipment] PRIMARY KEY CLUSTERED 
(
	[ActivityEquipment_Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY] 
) ON [PRIMARY]

ALTER TABLE [dbo].[ActivityEquipment]  WITH CHECK ADD  CONSTRAINT [FK_ActivityEquipment_Equipment] FOREIGN KEY([Equipment_Id])
REFERENCES [dbo].[Equipment] ([Equipment_Id])

ALTER TABLE [dbo].[ActivityEquipment] CHECK CONSTRAINT [FK_ActivityEquipment_Equipment]


ALTER TABLE [dbo].[ActivityEquipment]  WITH CHECK ADD  CONSTRAINT [FK_ActivityEquipment_Activity] FOREIGN KEY([Activity_Id])
REFERENCES [dbo].[Activity] ([Activity_Id])

ALTER TABLE [dbo].[ActivityEquipment] CHECK CONSTRAINT [FK_ActivityEquipment_Activity]

END