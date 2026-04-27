SELECT
    COUNT(*)
FROM [dbo].[ACCOUNT_HOLDERS]
WHERE EXISTS (
    SELECT 1
    FROM [dbo].[ACCOUNTS] qc_sd_p
    WHERE qc_sd_p.[ID] = [dbo].[ACCOUNT_HOLDERS].[ACCOUNT_ID]
      AND qc_sd_p.[IsDeleted] = 0);