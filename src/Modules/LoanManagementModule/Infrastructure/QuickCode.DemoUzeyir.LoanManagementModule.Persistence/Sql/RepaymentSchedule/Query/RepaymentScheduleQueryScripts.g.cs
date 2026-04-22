namespace QuickCode.DemoUzeyir.LoanManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class RepaymentSchedule
    {
        public static class Query
        {
            private const string _prefix = "LoanManagementModule.RepaymentSchedule.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByLoanId => ResourceKey("GetByLoanId.g.sql");
            public static string GetUpcomingPayments => ResourceKey("GetUpcomingPayments.g.sql");
            public static string GetOverduePayments => ResourceKey("GetOverduePayments.g.sql");
        }
    }
}