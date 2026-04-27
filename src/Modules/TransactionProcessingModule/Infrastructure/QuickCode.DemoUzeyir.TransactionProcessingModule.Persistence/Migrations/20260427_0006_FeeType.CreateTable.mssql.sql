IF OBJECT_ID(N'dbo.FEE_TYPES', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[FEE_TYPES] (
        [ID] int IDENTITY(1,1) NOT NULL,
        [CODE] nvarchar(50) NOT NULL,
        [NAME] nvarchar(250) NOT NULL,
        [FIXED_AMOUNT] decimal(18,2) NOT NULL,
        [PERCENTAGE_RATE] decimal(18,2) NOT NULL,
        [IS_ACTIVE] bit NOT NULL DEFAULT 1,
        [IsDeleted] bit NOT NULL DEFAULT 0,
        [DeletedOnUtc] datetime2(7) NULL,
        CONSTRAINT [PK_FEE_TYPES] PRIMARY KEY ([ID])
    );
END;