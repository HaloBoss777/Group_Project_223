IF NOT EXISTS 
(
	SELECT * FROM [information_schema].[columns] 
	WHERE table_name = 'Client' 
	AND table_schema = 'dbo'
	AND column_name = 'PasswordHash'
)
BEGIN
	ALTER TABLE [dbo].[Client] ADD [PasswordHash] varchar(max) 
END