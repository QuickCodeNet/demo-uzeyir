UPDATE [dbo].[LOAN_PRODUCTS]
SET [IsDeleted] = 1, [DeletedOnUtc] = SYSUTCDATETIME()
WHERE
    [ID] = @PRM_LOAN_PRODUCT_ID
    AND [IsDeleted] = 0;