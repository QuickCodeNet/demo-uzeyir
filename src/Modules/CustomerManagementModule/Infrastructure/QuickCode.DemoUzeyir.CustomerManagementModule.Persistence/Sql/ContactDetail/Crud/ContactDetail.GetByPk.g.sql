SELECT
    [ID],
    [CUSTOMER_ID],
    [TYPE],
    [VALUE],
    [IS_VERIFIED]
FROM [dbo].[CONTACT_DETAILS]
WHERE
    [ID] = @PRM_CONTACT_DETAIL_ID
    AND [IsDeleted] = 0;