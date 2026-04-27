UPDATE [dbo].[CONTACT_DETAILS]
SET [IsDeleted] = 1, [DeletedOnUtc] = SYSUTCDATETIME()
WHERE
    [ID] = @PRM_CONTACT_DETAIL_ID
    AND [IsDeleted] = 0;