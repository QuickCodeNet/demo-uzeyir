SELECT
    [ID],
    [CODE],
    [NAME],
    [FIXED_AMOUNT],
    [PERCENTAGE_RATE],
    [IS_ACTIVE]
FROM [dbo].[FEE_TYPES]
WHERE
    [ID] = @PRM_FEE_TYPE_ID
    AND [IsDeleted] = 0;