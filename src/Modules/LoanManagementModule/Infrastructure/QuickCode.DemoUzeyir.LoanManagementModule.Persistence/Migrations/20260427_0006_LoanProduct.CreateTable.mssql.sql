IF OBJECT_ID(N'dbo.LOAN_PRODUCTS', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[LOAN_PRODUCTS] (
        [ID] int IDENTITY(1,1) NOT NULL,
        [CODE] nvarchar(50) NOT NULL,
        [NAME] nvarchar(250) NOT NULL,
        [MIN_AMOUNT] decimal(18,2) NOT NULL,
        [MAX_AMOUNT] decimal(18,2) NOT NULL,
        [MIN_TERM_MONTHS] int NOT NULL,
        [MAX_TERM_MONTHS] int NOT NULL,
        [INTEREST_RATE] decimal(18,2) NOT NULL,
        [IS_ACTIVE] bit NOT NULL DEFAULT 1,
        [IsDeleted] bit NOT NULL DEFAULT 0,
        [DeletedOnUtc] datetime2(7) NULL,
        CONSTRAINT [PK_LOAN_PRODUCTS] PRIMARY KEY ([ID])
    );
END;