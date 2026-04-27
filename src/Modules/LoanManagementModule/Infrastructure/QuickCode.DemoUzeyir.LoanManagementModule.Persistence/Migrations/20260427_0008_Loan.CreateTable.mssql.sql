IF OBJECT_ID(N'dbo.LOANS', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[LOANS] (
        [ID] int IDENTITY(1,1) NOT NULL,
        [LOAN_ACCOUNT_NUMBER] nvarchar(50) NOT NULL,
        [APPLICATION_ID] int NOT NULL,
        [CUSTOMER_ID] int NOT NULL,
        [PRINCIPAL_AMOUNT] decimal(18,2) NOT NULL,
        [OUTSTANDING_BALANCE] decimal(18,2) NOT NULL,
        [INTEREST_RATE] decimal(18,2) NOT NULL,
        [TERM_MONTHS] int NOT NULL,
        [DISBURSEMENT_DATE] datetime2(7) NOT NULL,
        [MATURITY_DATE] datetime2(7) NOT NULL,
        [STATUS] nvarchar(max) NOT NULL DEFAULT 'ACTIVE',
        [IsDeleted] bit NOT NULL DEFAULT 0,
        [DeletedOnUtc] datetime2(7) NULL,
        CONSTRAINT [PK_LOANS] PRIMARY KEY ([ID])
    );
END;