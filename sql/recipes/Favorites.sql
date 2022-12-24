CREATE TABLE [dbo].[Favorites]
(
	[FavoriteId]	UNIQUEIDENTIFIER	NOT NULL CONSTRAINT [DF_Favorites_FavoriteId] DEFAULT NEWID(),
	[RecipeId]		UNIQUEIDENTIFIER	NOT NULL,
	[UserId]		UNIQUEIDENTIFIER	NOT NULL,

	CONSTRAINT [PK_Favorites]					PRIMARY KEY ([FavoriteId]),
	CONSTRAINT [FK_Favorites_RecipeId]			FOREIGN KEY ([RecipeId]) REFERENCES [Recipes]([RecipeId]) ON DELETE CASCADE,
	CONSTRAINT [UK_Favorites_UserId_RecipeId]	UNIQUE ([UserId], [RecipeId])
)
GO

CREATE INDEX [IX_dbo_Favorites_RecipeId] ON [dbo].[Favorites]([RecipeId])
GO

CREATE INDEX [IX_dbo_Favorites_UserId] ON [dbo].[Favorites]([UserId])
GO