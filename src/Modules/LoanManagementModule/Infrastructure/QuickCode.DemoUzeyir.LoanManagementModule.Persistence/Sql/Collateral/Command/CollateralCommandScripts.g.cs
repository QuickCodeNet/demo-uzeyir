namespace QuickCode.DemoUzeyir.LoanManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Collateral
    {
        public static class Command
        {
            private const string _prefix = "LoanManagementModule.Collateral.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string UpdateMarketValue => ResourceKey("UpdateMarketValue.g.sql");
        }
    }
}