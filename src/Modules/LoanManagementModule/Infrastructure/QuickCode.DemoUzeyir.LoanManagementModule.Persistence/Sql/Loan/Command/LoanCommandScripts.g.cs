namespace QuickCode.DemoUzeyir.LoanManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Loan
    {
        public static class Command
        {
            private const string _prefix = "LoanManagementModule.Loan.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string UpdateOutstandingBalance => ResourceKey("UpdateOutstandingBalance.g.sql");
            public static string MarkAsPaidOff => ResourceKey("MarkAsPaidOff.g.sql");
            public static string MarkAsDefaulted => ResourceKey("MarkAsDefaulted.g.sql");
        }
    }
}