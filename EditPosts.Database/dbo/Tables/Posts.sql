CREATE TABLE [dbo].[Posts] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [PostDate] DATETIME       NOT NULL,
    [HitCount] INT            NOT NULL,
    [Name]     NVARCHAR (255) NOT NULL,
    [Body]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED ([Id] ASC)
);

