UPDATE [dbo].[DOCUMENT_TYPES]
SET [IsDeleted] = 1, [DeletedOnUtc] = SYSUTCDATETIME()
WHERE
    [ID] = @PRM_DOCUMENT_TYPE_ID
    AND [IsDeleted] = 0;