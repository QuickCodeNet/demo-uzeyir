SELECT
    [ID],
    [ACCOUNT_ID],
    [CARD_NUMBER],
    [CARD_HOLDER_NAME],
    [CARD_TYPE_ID],
    [EXPIRY_MONTH],
    [EXPIRY_YEAR],
    [CVV],
    [STATUS],
    [ACTIVATION_DATE],
    [IS_ACTIVE]
FROM [dbo].[CARDS]
WHERE
    [ID] = @PRM_CARD_ID
    AND [IsDeleted] = 0;