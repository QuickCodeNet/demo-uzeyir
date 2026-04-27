namespace QuickCode.DemoUzeyir.AccountManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class AccountHolder
    {
        public static class Query
        {
            private const string _prefix = "AccountManagementModule.AccountHolder.Query";
            private const string _sqlScriptStem = "AccountHolder";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetHoldersByAccountId => ResourceKey($"{_sqlScriptStem}.GetHoldersByAccountId.g.sql");
            public static string GetAccountsByHolderId => ResourceKey($"{_sqlScriptStem}.GetAccountsByHolderId.g.sql");
        }
    }
}