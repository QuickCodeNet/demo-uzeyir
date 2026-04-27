namespace QuickCode.DemoUzeyir.LoanManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class RepaymentSchedule
    {
        public static class Command
        {
            private const string _prefix = "LoanManagementModule.RepaymentSchedule.Command";
            private const string _sqlScriptStem = "RepaymentSchedule";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string MarkAsPaid => ResourceKey($"{_sqlScriptStem}.MarkAsPaid.g.sql");
        }
    }
}