CREATE TABLE [dbo].[Goals]
(
	[GoalId]	UNIQUEIDENTIFIER	NOT NULL CONSTRAINT [DF_Goals_GoalId] DEFAULT (newid()),
	[UserId]	UNIQUEIDENTIFIER	NOT NULL,
	[Calories]	INT					NOT NULL,
	[Carbs]		INT					NOT NULL,
	[Fats]		INT					NOT NULL,
	[Proteins]	INT					NOT NULL,
	
	CONSTRAINT [PK_Goals] PRIMARY KEY CLUSTERED ([GoalId] ASC),
	CONSTRAINT [CC_Goals_Carbs] CHECK ([Carbs]>=(0)),
    CONSTRAINT [CC_Goals_Fats] CHECK ([Fats]>=(0)),
    CONSTRAINT [CC_Goals_Proteins] CHECK ([Proteins]>=(0)),
    CONSTRAINT [CC_Goals_Calories] CHECK ([Calories]>=(0)),
	CONSTRAINT [CC_Goals_UserId] UNIQUE ([UserId])
)
GO

CREATE NONCLUSTERED INDEX [IX_dbo_Goals_UserId]
ON [dbo].[Goals]([UserId] ASC)
GO