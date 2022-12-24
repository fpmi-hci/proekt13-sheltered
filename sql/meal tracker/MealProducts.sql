CREATE TABLE [dbo].[MealProducts]
(
	[MealProductId] UNIQUEIDENTIFIER	NOT NULL CONSTRAINT [DF_MealProducts_MealProductId] DEFAULT (newid()),
	[MealId]		UNIQUEIDENTIFIER	NOT NULL,
	[ProductId]		UNIQUEIDENTIFIER	NOT NULL,
	[Weight]		INT					NOT NULL,

	CONSTRAINT [PK_MealProducts] PRIMARY KEY CLUSTERED ([MealProductId] ASC),
	CONSTRAINT [FK_MealProducts_MealId] FOREIGN KEY ([MealId]) REFERENCES [dbo].[Meals] ([MealId]) ON DELETE CASCADE,
	CONSTRAINT [FK_MealProducts_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([ProductId]) ON DELETE CASCADE,
	CONSTRAINT [CC_MealProducts_Weight] CHECK ([Weight]>=(0)),
	CONSTRAINT [UC_MealProducts_MealId_ProductId] UNIQUE ([MealId], [ProductId])
)
GO

CREATE NONCLUSTERED INDEX [IX_dbo_MealProducts_MealId]
ON [dbo].[MealProducts]([MealId] ASC)
GO