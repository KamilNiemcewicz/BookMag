/*
   15 lipca 201712:59:46
   User: 
   Server: .\SHOP
   Database: M:\PROGRAMOWANIE\C#\PROJECTS\BECOMING A SOFTWARE DEVELOPER\SHOP\SHOP\SHOPDB.MDF
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Book
	DROP COLUMN e
GO
ALTER TABLE dbo.Book SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
