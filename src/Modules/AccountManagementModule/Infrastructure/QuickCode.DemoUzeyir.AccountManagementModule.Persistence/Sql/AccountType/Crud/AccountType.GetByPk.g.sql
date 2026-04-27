SELECT
    [ID],
    [CODE],
    [NAME],
    [INTEREST_RATE],
    [MINIMUM_BALANCE],
    [IS_ACTIVE]
FROM [dbo].[ACCOUNT_TYPES]
WHERE
    [ID] = @PRM_ACCOUNT_TYPE_ID
    AND [IsDeleted] = 0;