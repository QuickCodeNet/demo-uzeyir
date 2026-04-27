UPDATE [dbo].[COLLATERALS]
SET [IsDeleted] = 1, [DeletedOnUtc] = SYSUTCDATETIME()
WHERE
    [ID] = @PRM_COLLATERAL_ID
    AND [IsDeleted] = 0;