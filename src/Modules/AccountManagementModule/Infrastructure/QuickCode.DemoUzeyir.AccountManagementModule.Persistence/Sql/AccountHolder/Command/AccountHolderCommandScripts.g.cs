namespace QuickCode.DemoUzeyir.AccountManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class AccountHolder
    {
        public static class Command
        {
            private const string _prefix = "AccountManagementModule.AccountHolder.Command";
            private const string _sqlScriptStem = "AccountHolder";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string RemoveHolder => ResourceKey($"{_sqlScriptStem}.RemoveHolder.g.sql");
        }
    }
}