CREATE TABLE [dbo].[Posts_Tags] (
    [Post_Id] INT NOT NULL,
    [Tag_Id]  INT NOT NULL,
    CONSTRAINT [FK_Posts_Tags_Posts] FOREIGN KEY ([Post_Id]) REFERENCES [dbo].[Posts] ([Id]),
    CONSTRAINT [FK_Posts_Tags_Tags] FOREIGN KEY ([Tag_Id]) REFERENCES [dbo].[Tags] ([Id])
);

