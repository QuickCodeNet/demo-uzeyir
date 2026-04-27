IF OBJECT_ID(N'dbo.ACCOUNTS', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[ACCOUNTS] (
        [ID] int IDENTITY(1,1) NOT NULL,
        [ACCOUNT_NUMBER] nvarchar(50) NOT NULL,
        [CUSTOMER_ID] int NOT NULL,
        [ACCOUNT_TYPE_ID] int NOT NULL,
        [CURRENCY_ID] int NOT NULL,
        [BALANCE] decimal(18,2) NOT NULL DEFAULT 0,
        [STATUS] nvarchar(max) NOT NULL DEFAULT 'PENDING_APPROVAL',
        [OPENED_DATE] datetime2(7) NOT NULL,
        [CLOSED_DATE] datetime2(7) NOT NULL,
        [IS_ACTIVE] bit NOT NULL DEFAULT 1,
        [IsDeleted] bit NOT NULL DEFAULT 0,
        [DeletedOnUtc] datetime2(7) NULL,
        CONSTRAINT [PK_ACCOUNTS] PRIMARY KEY ([ID])
    );
END;