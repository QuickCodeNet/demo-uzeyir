IF OBJECT_ID(N'dbo.LOAN_PAYMENTS', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[LOAN_PAYMENTS] (
        [ID] int IDENTITY(1,1) NOT NULL,
        [LOAN_ID] int NOT NULL,
        [SCHEDULE_ID] int NOT NULL,
        [PAYMENT_REFERENCE] uniqueidentifier NOT NULL,
        [AMOUNT_PAID] decimal(18,2) NOT NULL,
        [PAYMENT_DATE] datetime2(7) NOT NULL,
        [PAYMENT_METHOD] nvarchar(50) NOT NULL,
        [IsDeleted] bit NOT NULL DEFAULT 0,
        [DeletedOnUtc] datetime2(7) NULL,
        CONSTRAINT [PK_LOAN_PAYMENTS] PRIMARY KEY ([ID])
    );
END;