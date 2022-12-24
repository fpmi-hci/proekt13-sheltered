CREATE TABLE [dbo].[Products]
(
	[ProductId] UNIQUEIDENTIFIER	NOT NULL CONSTRAINT [DF_Products_ProductId] DEFAULT (newid()),
	[Name]		NVARCHAR(64)		NOT NULL,
	[Calories]	INT					NOT NULL,
	[Carbs]		FLOAT				NOT NULL,
	[Proteins]	FLOAT				NOT NULL,
	[Fats]		FLOAT				NOT NULL,
	[Portion]	INT					NOT NULL,


	CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([ProductId] ASC)
)
GO

CREATE NONCLUSTERED INDEX [IX_dbo_Recipes_Name]
ON [dbo].[Products]([Name] ASC)
GO