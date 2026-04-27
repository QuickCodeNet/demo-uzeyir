SELECT
    [ID],
    [CODE],
    [NAME],
    [IS_ACTIVE]
FROM [dbo].[COLLATERAL_TYPES]
WHERE
    [ID] = @PRM_COLLATERAL_TYPE_ID
    AND [IsDeleted] = 0;