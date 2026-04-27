UPDATE [dbo].[FEE_TYPES]
SET [IsDeleted] = 1, [DeletedOnUtc] = SYSUTCDATETIME()
WHERE
    [ID] = @PRM_FEE_TYPE_ID
    AND [IsDeleted] = 0;