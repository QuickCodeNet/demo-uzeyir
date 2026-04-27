IF OBJECT_ID(N'dbo.TRANSACTIONS', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[TRANSACTIONS] (
        [ID] bigint IDENTITY(1,1) NOT NULL,
        [TRANSACTION_REFERENCE] uniqueidentifier NOT NULL,
        [SOURCE_ACCOUNT_ID] int NULL,
        [DESTINATION_ACCOUNT_ID] int NULL,
        [TRANSACTION_TYPE_ID] int NOT NULL,
        [TRANSACTION_CHANNEL_ID] int NOT NULL,
        [AMOUNT] decimal(18,2) NOT NULL,
        [CURRENCY_CODE] nvarchar(50) NOT NULL,
        [DESCRIPTION] nvarchar(1000) NOT NULL,
        [STATUS] nvarchar(max) NOT NULL DEFAULT 'PENDING',
        [TRANSACTION_DATE] datetime2(7) NOT NULL,
        [COMPLETED_DATE] datetime2(7) NOT NULL,
        [IsDeleted] bit NOT NULL DEFAULT 0,
        [DeletedOnUtc] datetime2(7) NULL,
        CONSTRAINT [PK_TRANSACTIONS] PRIMARY KEY ([ID])
    );
END;