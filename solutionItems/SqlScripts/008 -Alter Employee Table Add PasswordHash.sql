IF NOT EXISTS 
(
	SELECT * FROM [information_schema].[columns] 
	WHERE table_name = 'Employee' 
	AND table_schema = 'dbo'
	AND column_name = 'PasswordHash'
)
BEGIN
	ALTER TABLE [dbo].[Employee] ADD [PasswordHash] varchar(max) 
END