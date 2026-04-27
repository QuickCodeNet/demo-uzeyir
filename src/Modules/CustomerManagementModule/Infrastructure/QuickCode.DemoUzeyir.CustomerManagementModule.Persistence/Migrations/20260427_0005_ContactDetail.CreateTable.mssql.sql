IF OBJECT_ID(N'dbo.CONTACT_DETAILS', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[CONTACT_DETAILS] (
        [ID] int IDENTITY(1,1) NOT NULL,
        [CUSTOMER_ID] int NOT NULL,
        [TYPE] nvarchar(max) NOT NULL,
        [VALUE] nvarchar(250) NOT NULL,
        [IS_VERIFIED] bit NOT NULL DEFAULT 0,
        [IsDeleted] bit NOT NULL DEFAULT 0,
        [DeletedOnUtc] datetime2(7) NULL,
        CONSTRAINT [PK_CONTACT_DETAILS] PRIMARY KEY ([ID])
    );
END;