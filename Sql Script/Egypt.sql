IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Blogs] (
    [BlogId] int NOT NULL IDENTITY,
    [Url] nvarchar(max),
    CONSTRAINT [PK_Blogs] PRIMARY KEY ([BlogId])
);

GO

CREATE TABLE [Posts] (
    [PostId] int NOT NULL IDENTITY,
    [BlogId] int NOT NULL,
    [Content] nvarchar(max),
    [Title] nvarchar(max),
    CONSTRAINT [PK_Posts] PRIMARY KEY ([PostId]),
    CONSTRAINT [FK_Posts_Blogs_BlogId] FOREIGN KEY ([BlogId]) REFERENCES [Blogs] ([BlogId]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Posts_BlogId] ON [Posts] ([BlogId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170628085256_MyFirstMigration', N'1.1.2');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170628085818_MyFirstMigration2', N'1.1.2');

GO

CREATE TABLE [Place] (
    [PlaceId] int NOT NULL IDENTITY,
    [Code] nvarchar(max),
    CONSTRAINT [PK_Place] PRIMARY KEY ([PlaceId])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170628125619_Third', N'1.1.2');

GO

CREATE TABLE [MultiKey] (
    [Session] int NOT NULL,
    [Version] int NOT NULL,
    CONSTRAINT [PK_MultiKey] PRIMARY KEY ([Session], [Version])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170628131502_MultiKey', N'1.1.2');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170628132606_MaxLen', N'1.1.2');

GO

ALTER TABLE [MultiKey] ADD [Description] nvarchar(200);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170628132727_MaxLen2', N'1.1.2');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'MultiKey') AND [c].[name] = N'Description');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [MultiKey] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [MultiKey] ALTER COLUMN [Description] nvarchar(200);
ALTER TABLE [MultiKey] ADD DEFAULT N' x-O-x' FOR [Description];

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170629090341_DefaultValue_MultiKeyTable', N'1.1.2');

GO

