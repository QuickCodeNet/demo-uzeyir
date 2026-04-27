UPDATE [dbo].[BENEFICIARIES]
SET [IsDeleted] = 1, [DeletedOnUtc] = SYSUTCDATETIME()
WHERE
    [ID] = @PRM_BENEFICIARY_ID
    AND [IsDeleted] = 0;