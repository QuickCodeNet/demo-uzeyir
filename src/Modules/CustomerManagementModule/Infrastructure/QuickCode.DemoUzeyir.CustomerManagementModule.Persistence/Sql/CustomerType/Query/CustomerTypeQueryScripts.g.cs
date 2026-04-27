namespace QuickCode.DemoUzeyir.CustomerManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class CustomerType
    {
        public static class Query
        {
            private const string _prefix = "CustomerManagementModule.CustomerType.Query";
            private const string _sqlScriptStem = "CustomerType";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetActive => ResourceKey($"{_sqlScriptStem}.GetActive.g.sql");
            public static string GetByCode => ResourceKey($"{_sqlScriptStem}.GetByCode.g.sql");
        }
    }
}