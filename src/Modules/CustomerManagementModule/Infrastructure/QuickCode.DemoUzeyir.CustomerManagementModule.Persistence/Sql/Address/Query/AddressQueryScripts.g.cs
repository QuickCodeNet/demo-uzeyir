namespace QuickCode.DemoUzeyir.CustomerManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Address
    {
        public static class Query
        {
            private const string _prefix = "CustomerManagementModule.Address.Query";
            private const string _sqlScriptStem = "Address";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByCustomerId => ResourceKey($"{_sqlScriptStem}.GetByCustomerId.g.sql");
            public static string GetPrimaryByCustomerId => ResourceKey($"{_sqlScriptStem}.GetPrimaryByCustomerId.g.sql");
        }
    }
}