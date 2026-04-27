SELECT
    [ID],
    [CUSTOMER_ID],
    [ADDRESS_LINE_1],
    [ADDRESS_LINE_2],
    [CITY],
    [STATE],
    [POSTAL_CODE],
    [COUNTRY_CODE],
    [TYPE],
    [IS_PRIMARY]
FROM [dbo].[ADDRESSES]
WHERE
    [ID] = @PRM_ADDRESS_ID
    AND [IsDeleted] = 0;