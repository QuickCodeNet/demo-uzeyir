namespace QuickCode.DemoUzeyir.AccountManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class AccountHolder
    {
        public static class Query
        {
            private const string _prefix = "AccountManagementModule.AccountHolder.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetHoldersByAccountId => ResourceKey("GetHoldersByAccountId.g.sql");
            public static string GetAccountsByHolderId => ResourceKey("GetAccountsByHolderId.g.sql");
        }
    }
}