SELECT
    [ID],
    [CODE],
    [NAME],
    [NETWORK],
    [IS_ACTIVE]
FROM [dbo].[CARD_TYPES]
WHERE
    [ID] = @PRM_CARD_TYPE_ID
    AND [IsDeleted] = 0;