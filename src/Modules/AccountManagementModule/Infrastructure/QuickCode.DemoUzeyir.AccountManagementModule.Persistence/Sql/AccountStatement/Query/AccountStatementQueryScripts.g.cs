namespace QuickCode.DemoUzeyir.AccountManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class AccountStatement
    {
        public static class Query
        {
            private const string _prefix = "AccountManagementModule.AccountStatement.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByAccountId => ResourceKey("GetByAccountId.g.sql");
            public static string GetByDateRange => ResourceKey("GetByDateRange.g.sql");
        }
    }
}