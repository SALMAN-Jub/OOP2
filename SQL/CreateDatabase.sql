-- CreateDatabase.sql: Creates HotelManagementDB only

-- Run this script in SQL Server (e.g., SSMS) connected to the instance in your App.config (Data Source=.\SQLEXPRESS)

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'HotelManagementDB')
BEGIN
    CREATE DATABASE [HotelManagementDB];
    PRINT 'Database HotelManagementDB created.';
END
ELSE
BEGIN
    PRINT 'Database HotelManagementDB already exists.';
END
GO

USE [HotelManagementDB];
GO

PRINT 'CreateDatabase.sql completed.';
GO
