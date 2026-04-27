namespace QuickCode.DemoUzeyir.LoanManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class LoanProduct
    {
        public static class Query
        {
            private const string _prefix = "LoanManagementModule.LoanProduct.Query";
            private const string _sqlScriptStem = "LoanProduct";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetActive => ResourceKey($"{_sqlScriptStem}.GetActive.g.sql");
            public static string GetByCode => ResourceKey($"{_sqlScriptStem}.GetByCode.g.sql");
        }
    }
}