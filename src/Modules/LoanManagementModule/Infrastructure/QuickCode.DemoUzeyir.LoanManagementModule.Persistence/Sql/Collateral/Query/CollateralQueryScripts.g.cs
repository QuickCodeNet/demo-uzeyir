namespace QuickCode.DemoUzeyir.LoanManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Collateral
    {
        public static class Query
        {
            private const string _prefix = "LoanManagementModule.Collateral.Query";
            private const string _sqlScriptStem = "Collateral";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByApplicationId => ResourceKey($"{_sqlScriptStem}.GetByApplicationId.g.sql");
            public static string GetCollateralsWithType => ResourceKey($"{_sqlScriptStem}.GetCollateralsWithType.g.sql");
        }
    }
}