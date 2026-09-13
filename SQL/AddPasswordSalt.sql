-- AddPasswordSalt.sql
USE HotelManagementDB;
GO

SET XACT_ABORT ON;

BEGIN TRY
	IF COL_LENGTH('dbo.Users','PasswordSalt') IS NULL
	BEGIN
		ALTER TABLE dbo.Users ADD PasswordSalt NVARCHAR(256) NULL;
		PRINT 'PasswordSalt column added to Users.';
	END
	ELSE
	BEGIN
		PRINT 'PasswordSalt column already exists.';
	END
END TRY
BEGIN CATCH
	PRINT 'Error adding PasswordSalt column:';
	PRINT ERROR_MESSAGE();
	THROW;
END CATCH
GO
