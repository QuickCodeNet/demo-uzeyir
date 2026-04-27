IF OBJECT_ID(N'dbo.PENDING_TRANSFERS', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[PENDING_TRANSFERS] (
        [ID] int IDENTITY(1,1) NOT NULL,
        [TRANSFER_REFERENCE] uniqueidentifier NOT NULL,
        [SOURCE_ACCOUNT_ID] int NOT NULL,
        [BENEFICIARY_ID] int NOT NULL,
        [AMOUNT] decimal(18,2) NOT NULL,
        [SCHEDULED_DATE] datetime2(7) NOT NULL,
        [STATUS] nvarchar(max) NOT NULL DEFAULT 'SCHEDULED',
        [CREATED_DATE] datetime2(7) NOT NULL,
        [IsDeleted] bit NOT NULL DEFAULT 0,
        [DeletedOnUtc] datetime2(7) NULL,
        CONSTRAINT [PK_PENDING_TRANSFERS] PRIMARY KEY ([ID])
    );
END;