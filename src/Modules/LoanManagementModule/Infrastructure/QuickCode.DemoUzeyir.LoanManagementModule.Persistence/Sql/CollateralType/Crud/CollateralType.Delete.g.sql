UPDATE [dbo].[COLLATERAL_TYPES]
SET [IsDeleted] = 1, [DeletedOnUtc] = SYSUTCDATETIME()
WHERE
    [ID] = @PRM_COLLATERAL_TYPE_ID
    AND [IsDeleted] = 0;