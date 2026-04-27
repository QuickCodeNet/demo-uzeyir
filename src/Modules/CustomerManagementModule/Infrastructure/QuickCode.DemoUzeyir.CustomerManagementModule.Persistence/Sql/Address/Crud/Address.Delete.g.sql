UPDATE [dbo].[ADDRESSES]
SET [IsDeleted] = 1, [DeletedOnUtc] = SYSUTCDATETIME()
WHERE
    [ID] = @PRM_ADDRESS_ID
    AND [IsDeleted] = 0;