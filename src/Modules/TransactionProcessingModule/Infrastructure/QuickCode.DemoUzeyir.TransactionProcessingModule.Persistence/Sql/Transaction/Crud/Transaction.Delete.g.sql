UPDATE [dbo].[TRANSACTIONS]
SET [IsDeleted] = 1, [DeletedOnUtc] = SYSUTCDATETIME()
WHERE
    [ID] = @PRM_TRANSACTION_ID
    AND [IsDeleted] = 0;