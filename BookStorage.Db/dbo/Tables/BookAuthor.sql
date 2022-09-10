CREATE TABLE [dbo].[BookAuthor]
(
	[BookId] UNIQUEIDENTIFIER FOREIGN KEY REFERENCES [dbo].[Book]([Id]) NOT NULL,
    [AuthorId] UNIQUEIDENTIFIER FOREIGN KEY REFERENCES [dbo].[Author]([Id]) NOT NULL,
    CONSTRAINT [PK_dbo_UserRole] PRIMARY KEY ([BookId], [AuthorId])
)
GO

CREATE INDEX [Index_dbo_BookAuthor_BookId] ON [dbo].[Book]([Id]);
GO

CREATE INDEX [Index_dbo_BookAuthor_AuthorId] ON [dbo].[Author]([Id]);
GO

