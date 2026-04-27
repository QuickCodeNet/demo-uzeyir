SELECT
    [ID],
    [CODE],
    [NAME],
    [SYMBOL],
    [IS_ACTIVE]
FROM [dbo].[CURRENCIES]
WHERE
    [ID] = @PRM_CURRENCY_ID
    AND [IsDeleted] = 0;