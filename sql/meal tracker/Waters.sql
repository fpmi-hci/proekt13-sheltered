CREATE TABLE [dbo].[Waters]
(
	[WaterId]	UNIQUEIDENTIFIER	NOT NULL CONSTRAINT [DF_Waters_WaterId] DEFAULT (newid()),
	[UserId]	UNIQUEIDENTIFIER	NOT NULL,
	[Date]		DATETIME2			NOT NULL,
	[Cups]		INT					NOT NULL,

	CONSTRAINT [PK_Waters] PRIMARY KEY CLUSTERED ([WaterId] ASC),
	CONSTRAINT [CC_Waters_Cups] CHECK ([Cups] >= 0)
)
GO

CREATE NONCLUSTERED INDEX [IX_dbo_Waters_UserId]
ON [dbo].[Waters]([UserId] ASC)
GO

CREATE NONCLUSTERED INDEX [IX_dbo_Waters_Date]
ON [dbo].[Waters]([Date] ASC)
GO