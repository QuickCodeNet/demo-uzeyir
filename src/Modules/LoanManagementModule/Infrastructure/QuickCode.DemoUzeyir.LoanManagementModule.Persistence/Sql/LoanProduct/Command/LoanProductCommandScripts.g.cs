namespace QuickCode.DemoUzeyir.LoanManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class LoanProduct
    {
        public static class Command
        {
            private const string _prefix = "LoanManagementModule.LoanProduct.Command";
            private const string _sqlScriptStem = "LoanProduct";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string UpdateInterestRate => ResourceKey($"{_sqlScriptStem}.UpdateInterestRate.g.sql");
            public static string Deactivate => ResourceKey($"{_sqlScriptStem}.Deactivate.g.sql");
        }
    }
}