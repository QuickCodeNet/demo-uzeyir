UPDATE [dbo].[CURRENCIES]
SET [IsDeleted] = 1, [DeletedOnUtc] = SYSUTCDATETIME()
WHERE
    [ID] = @PRM_CURRENCY_ID
    AND [IsDeleted] = 0;