CREATE TABLE [dbo].[Steps]
(
	[StepId]		UNIQUEIDENTIFIER	NOT NULL CONSTRAINT [DF_Steps_StepId] DEFAULT NEWID(),
	[RecipeId]		UNIQUEIDENTIFIER	NOT NULL,
	[Number]		INT					NOT NULL,
	[Description]	NVARCHAR(MAX)		NOT NULL,

	CONSTRAINT [PK_Steps]			PRIMARY KEY ([StepId]),
	CONSTRAINT [FK_Steps_RecipeId]	FOREIGN KEY ([RecipeId]) REFERENCES [Recipes]([RecipeId]) ON DELETE CASCADE
)
GO

CREATE INDEX [IX_dbo_Steps_RecipeId] ON [dbo].[Steps]([RecipeId])
GO