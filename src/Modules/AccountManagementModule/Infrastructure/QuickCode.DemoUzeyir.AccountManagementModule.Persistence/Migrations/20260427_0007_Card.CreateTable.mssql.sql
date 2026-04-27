IF OBJECT_ID(N'dbo.CARDS', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[CARDS] (
        [ID] int IDENTITY(1,1) NOT NULL,
        [ACCOUNT_ID] int NOT NULL,
        [CARD_NUMBER] nvarchar(250) NOT NULL,
        [CARD_HOLDER_NAME] nvarchar(250) NOT NULL,
        [CARD_TYPE_ID] int NOT NULL,
        [EXPIRY_MONTH] tinyint NOT NULL,
        [EXPIRY_YEAR] tinyint NOT NULL,
        [CVV] nvarchar(50) NOT NULL,
        [STATUS] nvarchar(max) NOT NULL DEFAULT 'INACTIVE',
        [ACTIVATION_DATE] datetime2(7) NOT NULL,
        [IS_ACTIVE] bit NOT NULL DEFAULT 1,
        [IsDeleted] bit NOT NULL DEFAULT 0,
        [DeletedOnUtc] datetime2(7) NULL,
        CONSTRAINT [PK_CARDS] PRIMARY KEY ([ID])
    );
END;