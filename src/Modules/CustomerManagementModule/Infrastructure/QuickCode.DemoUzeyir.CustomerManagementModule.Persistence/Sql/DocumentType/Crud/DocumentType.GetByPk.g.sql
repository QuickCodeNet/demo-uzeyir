SELECT
    [ID],
    [CODE],
    [NAME],
    [IS_ACTIVE]
FROM [dbo].[DOCUMENT_TYPES]
WHERE
    [ID] = @PRM_DOCUMENT_TYPE_ID
    AND [IsDeleted] = 0;