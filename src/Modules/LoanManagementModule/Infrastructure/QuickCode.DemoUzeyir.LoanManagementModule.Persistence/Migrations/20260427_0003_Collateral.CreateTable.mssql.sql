IF OBJECT_ID(N'dbo.COLLATERALS', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[COLLATERALS] (
        [ID] int IDENTITY(1,1) NOT NULL,
        [LOAN_APPLICATION_ID] int NOT NULL,
        [COLLATERAL_TYPE_ID] int NOT NULL,
        [DESCRIPTION] nvarchar(1000) NOT NULL,
        [MARKET_VALUE] decimal(18,2) NOT NULL,
        [VALUATION_DATE] datetime2(7) NOT NULL,
        [IsDeleted] bit NOT NULL DEFAULT 0,
        [DeletedOnUtc] datetime2(7) NULL,
        CONSTRAINT [PK_COLLATERALS] PRIMARY KEY ([ID])
    );
END;