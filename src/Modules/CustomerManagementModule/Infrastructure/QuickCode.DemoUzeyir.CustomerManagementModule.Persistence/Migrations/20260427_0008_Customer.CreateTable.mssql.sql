IF OBJECT_ID(N'dbo.CUSTOMERS', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[CUSTOMERS] (
        [ID] int IDENTITY(1,1) NOT NULL,
        [CUSTOMER_NUMBER] uniqueidentifier NOT NULL,
        [FIRST_NAME] nvarchar(250) NOT NULL,
        [LAST_NAME] nvarchar(250) NOT NULL,
        [DATE_OF_BIRTH] datetime2(7) NOT NULL,
        [CUSTOMER_TYPE_ID] int NOT NULL,
        [STATUS] nvarchar(max) NOT NULL DEFAULT 'PROSPECT',
        [CREATED_DATE] datetime2(7) NOT NULL,
        [IS_ACTIVE] bit NOT NULL DEFAULT 1,
        [IsDeleted] bit NOT NULL DEFAULT 0,
        [DeletedOnUtc] datetime2(7) NULL,
        CONSTRAINT [PK_CUSTOMERS] PRIMARY KEY ([ID])
    );
END;