UPDATE [dbo].[TRANSACTION_FEES]
SET [IsDeleted] = 1, [DeletedOnUtc] = SYSUTCDATETIME()
WHERE
    [ID] = @PRM_TRANSACTION_FEE_ID
    AND [IsDeleted] = 0;