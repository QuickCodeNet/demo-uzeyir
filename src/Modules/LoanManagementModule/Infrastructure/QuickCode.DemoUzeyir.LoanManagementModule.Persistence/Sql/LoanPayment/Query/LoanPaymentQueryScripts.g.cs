namespace QuickCode.DemoUzeyir.LoanManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class LoanPayment
    {
        public static class Query
        {
            private const string _prefix = "LoanManagementModule.LoanPayment.Query";
            private const string _sqlScriptStem = "LoanPayment";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByLoanId => ResourceKey($"{_sqlScriptStem}.GetByLoanId.g.sql");
            public static string GetByDateRange => ResourceKey($"{_sqlScriptStem}.GetByDateRange.g.sql");
            public static string GetTotalPaymentsForLoan => ResourceKey($"{_sqlScriptStem}.GetTotalPaymentsForLoan.g.sql");
        }
    }
}