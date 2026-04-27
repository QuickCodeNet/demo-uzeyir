IF OBJECT_ID(N'dbo.LOAN_APPLICATIONS', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[LOAN_APPLICATIONS] (
        [ID] int IDENTITY(1,1) NOT NULL,
        [APPLICATION_NUMBER] uniqueidentifier NOT NULL,
        [CUSTOMER_ID] int NOT NULL,
        [LOAN_PRODUCT_ID] int NOT NULL,
        [REQUESTED_AMOUNT] decimal(18,2) NOT NULL,
        [REQUESTED_TERM_MONTHS] int NOT NULL,
        [PURPOSE] nvarchar(1000) NOT NULL,
        [STATUS] nvarchar(max) NOT NULL DEFAULT 'DRAFT',
        [SUBMITTED_DATE] datetime2(7) NOT NULL,
        [DECISION_DATE] datetime2(7) NOT NULL,
        [IsDeleted] bit NOT NULL DEFAULT 0,
        [DeletedOnUtc] datetime2(7) NULL,
        CONSTRAINT [PK_LOAN_APPLICATIONS] PRIMARY KEY ([ID])
    );
END;