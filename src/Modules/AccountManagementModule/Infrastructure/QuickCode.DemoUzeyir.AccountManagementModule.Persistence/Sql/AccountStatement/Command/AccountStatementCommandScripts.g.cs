namespace QuickCode.DemoUzeyir.AccountManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class AccountStatement
    {
        public static class Command
        {
            private const string _prefix = "AccountManagementModule.AccountStatement.Command";
            private const string _sqlScriptStem = "AccountStatement";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string DeleteStatement => ResourceKey($"{_sqlScriptStem}.DeleteStatement.g.sql");
        }
    }
}