IF OBJECT_ID(N'dbo.ACCOUNT_TYPES', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[ACCOUNT_TYPES] (
        [ID] int IDENTITY(1,1) NOT NULL,
        [CODE] nvarchar(50) NOT NULL,
        [NAME] nvarchar(250) NOT NULL,
        [INTEREST_RATE] decimal(18,2) NOT NULL DEFAULT 0,
        [MINIMUM_BALANCE] decimal(18,2) NOT NULL DEFAULT 0,
        [IS_ACTIVE] bit NOT NULL DEFAULT 1,
        [IsDeleted] bit NOT NULL DEFAULT 0,
        [DeletedOnUtc] datetime2(7) NULL,
        CONSTRAINT [PK_ACCOUNT_TYPES] PRIMARY KEY ([ID])
    );
END;