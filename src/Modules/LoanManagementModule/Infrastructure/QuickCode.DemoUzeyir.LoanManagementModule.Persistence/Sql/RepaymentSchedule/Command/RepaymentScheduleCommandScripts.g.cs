namespace QuickCode.DemoUzeyir.LoanManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class RepaymentSchedule
    {
        public static class Command
        {
            private const string _prefix = "LoanManagementModule.RepaymentSchedule.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string MarkAsPaid => ResourceKey("MarkAsPaid.g.sql");
        }
    }
}