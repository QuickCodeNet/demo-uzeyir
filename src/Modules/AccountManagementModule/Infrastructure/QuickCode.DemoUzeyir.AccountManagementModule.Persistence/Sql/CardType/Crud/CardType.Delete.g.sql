UPDATE [dbo].[CARD_TYPES]
SET [IsDeleted] = 1, [DeletedOnUtc] = SYSUTCDATETIME()
WHERE
    [ID] = @PRM_CARD_TYPE_ID
    AND [IsDeleted] = 0;