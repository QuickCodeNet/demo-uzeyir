IF OBJECT_ID(N'dbo.ADDRESSES', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[ADDRESSES] (
        [ID] int IDENTITY(1,1) NOT NULL,
        [CUSTOMER_ID] int NOT NULL,
        [ADDRESS_LINE_1] nvarchar(250) NOT NULL,
        [ADDRESS_LINE_2] nvarchar(250) NOT NULL,
        [CITY] nvarchar(250) NOT NULL,
        [STATE] nvarchar(250) NOT NULL,
        [POSTAL_CODE] nvarchar(50) NOT NULL,
        [COUNTRY_CODE] nvarchar(50) NOT NULL,
        [TYPE] nvarchar(max) NOT NULL,
        [IS_PRIMARY] bit NOT NULL DEFAULT 0,
        [IsDeleted] bit NOT NULL DEFAULT 0,
        [DeletedOnUtc] datetime2(7) NULL,
        CONSTRAINT [PK_ADDRESSES] PRIMARY KEY ([ID])
    );
END;