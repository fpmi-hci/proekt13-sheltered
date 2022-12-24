CREATE TABLE [dbo].[Recipes]
(
	[RecipeId]		UNIQUEIDENTIFIER	NOT NULL	CONSTRAINT [DF_Recipes_RecipeId]	DEFAULT NEWID(),
	[Name]			NVARCHAR(64)		NOT NULL,
	[Carbs]			INT					NOT NULL,
	[Fats]			INT					NOT NULL,
	[Proteins]		INT					NOT NULL,
	[Calories]		INT					NOT NULL,
	[ImgUrl]		NVARCHAR(MAX)		NOT NULL,
	[Time]			NVARCHAR(12)		NOT NULL,

	CONSTRAINT [PK_Recipes]				PRIMARY KEY ([RecipeId]),
	CONSTRAINT [CC_Recipes_Carbs]		CHECK([Carbs] >= 0),
	CONSTRAINT [CC_Recipes_Fats]		CHECK([Fats] >= 0),
	CONSTRAINT [CC_Recipes_Proteins]	CHECK([Proteins] >= 0),
	CONSTRAINT [CC_Recipes_Calories]	CHECK([Calories] >= 0)
)
GO

CREATE INDEX [IX_dbo_Recipes_Name] ON [dbo].[Recipes]([Name])
GO