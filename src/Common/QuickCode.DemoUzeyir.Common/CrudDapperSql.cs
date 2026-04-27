namespace QuickCode.DemoUzeyir.Common;

public static class CrudDapperSql
{
    public const string MySqlLastInsertId = "SELECT CAST(LAST_INSERT_ID() AS SIGNED);";
}
