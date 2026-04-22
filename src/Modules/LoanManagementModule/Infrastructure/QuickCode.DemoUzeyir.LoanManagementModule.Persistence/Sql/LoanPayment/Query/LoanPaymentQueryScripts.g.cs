namespace QuickCode.DemoUzeyir.LoanManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class LoanPayment
    {
        public static class Query
        {
            private const string _prefix = "LoanManagementModule.LoanPayment.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByLoanId => ResourceKey("GetByLoanId.g.sql");
            public static string GetByDateRange => ResourceKey("GetByDateRange.g.sql");
            public static string GetTotalPaymentsForLoan => ResourceKey("GetTotalPaymentsForLoan.g.sql");
        }
    }
}