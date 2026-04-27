UPDATE [dbo].[LOANS]
SET [IsDeleted] = 1, [DeletedOnUtc] = SYSUTCDATETIME()
WHERE
    [ID] = @PRM_LOAN_ID
    AND [IsDeleted] = 0;