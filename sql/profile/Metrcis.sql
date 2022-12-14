CREATE TABLE [dbo].[Metrics]
(
	[MetricId]	UNIQUEIDENTIFIER CONSTRAINT [DF_Meals_MealId] DEFAULT (newid()) NOT NULL,
	[UserId]	UNIQUEIDENTIFIER	NOT NULL,
	[Weight]	FLOAT				NOT NULL,
	[Height]	INT					NOT NULL,
	[Date]		DATETIME2			NOT NULL,

	CONSTRAINT [PK_Metrics] PRIMARY KEY CLUSTERED ([MetricId] ASC)
)
GO

CREATE NONCLUSTERED INDEX [IX_dbo_Metrics_UserId]
ON [dbo].[Metrics]([UserId] ASC)
GO