BEGIN TRANSACTION;
GO

ALTER TABLE [Employees] ADD [Age] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210509095801_age', N'5.0.5');
GO

COMMIT;
GO

