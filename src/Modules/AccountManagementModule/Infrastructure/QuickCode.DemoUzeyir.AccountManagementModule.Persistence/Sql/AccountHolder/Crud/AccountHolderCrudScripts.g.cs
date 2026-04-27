namespace QuickCode.DemoUzeyir.AccountManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class AccountHolder
    {
        public static class Crud
        {
            private const string _prefix = "AccountManagementModule.AccountHolder.Crud";
            private const string _sqlScriptStem = "AccountHolder";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string Insert => ResourceKey($"{_sqlScriptStem}.Insert.g.sql");
            public static string Update => ResourceKey($"{_sqlScriptStem}.Update.g.sql");
            public static string Delete => ResourceKey($"{_sqlScriptStem}.Delete.g.sql");
            public static string GetByPk => ResourceKey($"{_sqlScriptStem}.GetByPk.g.sql");
            public static string List => ResourceKey($"{_sqlScriptStem}.List.g.sql");
            public static string Count => ResourceKey($"{_sqlScriptStem}.Count.g.sql");
        }
    }
}