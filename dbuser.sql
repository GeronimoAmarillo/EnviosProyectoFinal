
USE [master]
GO
CREATE LOGIN [EnviosDBManager] WITH PASSWORD='EnviosService'
GO
EXEC master..sp_addsrvrolemember @loginame = N'EnviosDBManager', @rolename = N'sysadmin'
GO
USE [EnviosContext]
GO
CREATE USER [EnviosDBManager] FOR LOGIN [EnviosDBManager] WITH DEFAULT_SCHEMA=[dbo]
GO
USE [EnviosContext]
GO
EXEC sp_addrolemember N'db_owner', N'EnviosDBManager'
GO
