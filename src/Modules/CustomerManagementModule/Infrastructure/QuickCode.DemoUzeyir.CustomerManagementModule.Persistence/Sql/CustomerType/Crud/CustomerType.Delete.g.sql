UPDATE [dbo].[CUSTOMER_TYPES]
SET [IsDeleted] = 1, [DeletedOnUtc] = SYSUTCDATETIME()
WHERE
    [ID] = @PRM_CUSTOMER_TYPE_ID
    AND [IsDeleted] = 0;