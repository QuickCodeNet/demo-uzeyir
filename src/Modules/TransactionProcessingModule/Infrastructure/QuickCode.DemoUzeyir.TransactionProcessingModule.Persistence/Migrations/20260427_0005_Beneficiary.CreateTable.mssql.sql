IF OBJECT_ID(N'dbo.BENEFICIARIES', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[BENEFICIARIES] (
        [ID] int IDENTITY(1,1) NOT NULL,
        [CUSTOMER_ID] int NOT NULL,
        [NICKNAME] nvarchar(250) NOT NULL,
        [BENEFICIARY_ACCOUNT_NUMBER] nvarchar(250) NOT NULL,
        [BENEFICIARY_NAME] nvarchar(250) NOT NULL,
        [BANK_NAME] nvarchar(250) NOT NULL,
        [BANK_CODE] nvarchar(50) NOT NULL,
        [TYPE] nvarchar(max) NOT NULL,
        [IS_ACTIVE] bit NOT NULL DEFAULT 1,
        [IsDeleted] bit NOT NULL DEFAULT 0,
        [DeletedOnUtc] datetime2(7) NULL,
        CONSTRAINT [PK_BENEFICIARIES] PRIMARY KEY ([ID])
    );
END;