UPDATE [dbo].[CUSTOMERS]
SET [IsDeleted] = 1, [DeletedOnUtc] = SYSUTCDATETIME()
WHERE
    [ID] = @PRM_CUSTOMER_ID
    AND [IsDeleted] = 0;