IF OBJECT_ID(N'dbo.CARD_TYPES', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[CARD_TYPES] (
        [ID] int IDENTITY(1,1) NOT NULL,
        [CODE] nvarchar(50) NOT NULL,
        [NAME] nvarchar(250) NOT NULL,
        [NETWORK] nvarchar(50) NOT NULL,
        [IS_ACTIVE] bit NOT NULL DEFAULT 1,
        [IsDeleted] bit NOT NULL DEFAULT 0,
        [DeletedOnUtc] datetime2(7) NULL,
        CONSTRAINT [PK_CARD_TYPES] PRIMARY KEY ([ID])
    );
END;