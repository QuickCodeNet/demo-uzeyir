IF OBJECT_ID(N'dbo.REPAYMENT_SCHEDULES', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[REPAYMENT_SCHEDULES] (
        [ID] int IDENTITY(1,1) NOT NULL,
        [LOAN_ID] int NOT NULL,
        [INSTALLMENT_NUMBER] int NOT NULL,
        [DUE_DATE] datetime2(7) NOT NULL,
        [PRINCIPAL_AMOUNT] decimal(18,2) NOT NULL,
        [INTEREST_AMOUNT] decimal(18,2) NOT NULL,
        [TOTAL_AMOUNT] decimal(18,2) NOT NULL,
        [STATUS] nvarchar(max) NOT NULL DEFAULT 'SCHEDULED',
        [IsDeleted] bit NOT NULL DEFAULT 0,
        [DeletedOnUtc] datetime2(7) NULL,
        CONSTRAINT [PK_REPAYMENT_SCHEDULES] PRIMARY KEY ([ID])
    );
END;