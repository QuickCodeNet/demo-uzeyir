IF OBJECT_ID(N'dbo.ACCOUNT_STATEMENTS', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[ACCOUNT_STATEMENTS] (
        [ID] int IDENTITY(1,1) NOT NULL,
        [ACCOUNT_ID] int NOT NULL,
        [STATEMENT_PERIOD_START] datetime2(7) NOT NULL,
        [STATEMENT_PERIOD_END] datetime2(7) NOT NULL,
        [GENERATED_DATE] datetime2(7) NOT NULL,
        [OPENING_BALANCE] decimal(18,2) NOT NULL,
        [CLOSING_BALANCE] decimal(18,2) NOT NULL,
        [STATEMENT_URL] nvarchar(1000) NOT NULL,
        [FORMAT] nvarchar(max) NOT NULL DEFAULT 'PDF',
        [IsDeleted] bit NOT NULL DEFAULT 0,
        [DeletedOnUtc] datetime2(7) NULL,
        CONSTRAINT [PK_ACCOUNT_STATEMENTS] PRIMARY KEY ([ID])
    );
END;