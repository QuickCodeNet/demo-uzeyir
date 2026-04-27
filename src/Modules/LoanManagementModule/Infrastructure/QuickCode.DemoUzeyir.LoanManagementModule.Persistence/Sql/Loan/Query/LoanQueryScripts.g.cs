namespace QuickCode.DemoUzeyir.LoanManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Loan
    {
        public static class Query
        {
            private const string _prefix = "LoanManagementModule.Loan.Query";
            private const string _sqlScriptStem = "Loan";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByAccountNumber => ResourceKey($"{_sqlScriptStem}.GetByAccountNumber.g.sql");
            public static string GetByCustomerId => ResourceKey($"{_sqlScriptStem}.GetByCustomerId.g.sql");
            public static string GetActiveLoans => ResourceKey($"{_sqlScriptStem}.GetActiveLoans.g.sql");
            public static string GetDefaultedLoans => ResourceKey($"{_sqlScriptStem}.GetDefaultedLoans.g.sql");
            public static string GetTotalOutstandingLoans => ResourceKey($"{_sqlScriptStem}.GetTotalOutstandingLoans.g.sql");
        }
    }
}