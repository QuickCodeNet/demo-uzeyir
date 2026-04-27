namespace QuickCode.DemoUzeyir.LoanManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class CollateralType
    {
        public static class Command
        {
            private const string _prefix = "LoanManagementModule.CollateralType.Command";
            private const string _sqlScriptStem = "CollateralType";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string Deactivate => ResourceKey($"{_sqlScriptStem}.Deactivate.g.sql");
        }
    }
}