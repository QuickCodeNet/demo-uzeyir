UPDATE [dbo].[ACCOUNTS]
SET [IsDeleted] = 1, [DeletedOnUtc] = SYSUTCDATETIME()
WHERE
    [ID] = @PRM_ACCOUNT_ID
    AND [IsDeleted] = 0;