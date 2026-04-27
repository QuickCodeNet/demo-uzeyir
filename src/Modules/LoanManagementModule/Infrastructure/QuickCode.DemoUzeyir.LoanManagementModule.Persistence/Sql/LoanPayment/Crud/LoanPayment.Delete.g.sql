UPDATE [dbo].[LOAN_PAYMENTS]
SET [IsDeleted] = 1, [DeletedOnUtc] = SYSUTCDATETIME()
WHERE
    [ID] = @PRM_LOAN_PAYMENT_ID
    AND [IsDeleted] = 0;