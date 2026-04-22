namespace QuickCode.DemoUzeyir.LoanManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Loan
    {
        public static class Query
        {
            private const string _prefix = "LoanManagementModule.Loan.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByAccountNumber => ResourceKey("GetByAccountNumber.g.sql");
            public static string GetByCustomerId => ResourceKey("GetByCustomerId.g.sql");
            public static string GetActiveLoans => ResourceKey("GetActiveLoans.g.sql");
            public static string GetDefaultedLoans => ResourceKey("GetDefaultedLoans.g.sql");
            public static string GetTotalOutstandingLoans => ResourceKey("GetTotalOutstandingLoans.g.sql");
        }
    }
}