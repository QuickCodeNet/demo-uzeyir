SELECT
    [ID],
    [CODE],
    [NAME],
    [DESCRIPTION],
    [IS_ACTIVE]
FROM [dbo].[CUSTOMER_TYPES]
WHERE
    [ID] = @PRM_CUSTOMER_TYPE_ID
    AND [IsDeleted] = 0;