IF OBJECT_ID(N'dbo.TRANSACTION_FEES', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[TRANSACTION_FEES] (
        [ID] int IDENTITY(1,1) NOT NULL,
        [TRANSACTION_ID] bigint NOT NULL,
        [FEE_TYPE_ID] int NOT NULL,
        [FEE_AMOUNT] decimal(18,2) NOT NULL,
        [APPLIED_DATE] datetime2(7) NOT NULL,
        [IsDeleted] bit NOT NULL DEFAULT 0,
        [DeletedOnUtc] datetime2(7) NULL,
        CONSTRAINT [PK_TRANSACTION_FEES] PRIMARY KEY ([ID])
    );
END;