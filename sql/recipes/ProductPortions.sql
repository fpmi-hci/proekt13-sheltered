CREATE TABLE [dbo].[ProductPortions]
(
	[ProductPortionId]	UNIQUEIDENTIFIER	NOT NULL	CONSTRAINT [DF_RecipeProducts_RecipeProductId] DEFAULT NEWID(),
	[RecipeId]			UNIQUEIDENTIFIER	NOT NULL,
	[ProductId]			UNIQUEIDENTIFIER	NOT NULL,
	[Portion]			NVARCHAR(50)		NOT NULL,

	CONSTRAINT [PK_RecipeProducts]				PRIMARY KEY ([ProductPortionId]),
	CONSTRAINT [FK_RecipeProducts_RecipeId]		FOREIGN KEY ([RecipeId])			REFERENCES [Recipes]([RecipeId])	ON DELETE CASCADE,
	CONSTRAINT [FK_RecipeProducts_ProductId]	FOREIGN KEY ([ProductId])			REFERENCES [Products]([ProductId])	ON DELETE CASCADE
)
GO

CREATE INDEX [IX_dbo_RecipeProducts_RecipeId] ON [dbo].[ProductPortions]([RecipeId])
GO

CREATE INDEX [IX_dbo_RecipeProducts_ProductId] ON [dbo].[ProductPortions]([ProductId])
GO