UPDATE [dbo].[CARDS]
SET [IsDeleted] = 1, [DeletedOnUtc] = SYSUTCDATETIME()
WHERE
    [ID] = @PRM_CARD_ID
    AND [IsDeleted] = 0;