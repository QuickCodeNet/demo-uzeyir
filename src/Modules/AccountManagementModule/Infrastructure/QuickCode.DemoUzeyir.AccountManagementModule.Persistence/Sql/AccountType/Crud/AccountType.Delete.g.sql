UPDATE [dbo].[ACCOUNT_TYPES]
SET [IsDeleted] = 1, [DeletedOnUtc] = SYSUTCDATETIME()
WHERE
    [ID] = @PRM_ACCOUNT_TYPE_ID
    AND [IsDeleted] = 0;