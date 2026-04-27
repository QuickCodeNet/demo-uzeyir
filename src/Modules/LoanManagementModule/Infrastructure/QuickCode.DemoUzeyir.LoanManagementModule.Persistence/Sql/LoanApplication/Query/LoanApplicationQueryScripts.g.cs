namespace QuickCode.DemoUzeyir.LoanManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class LoanApplication
    {
        public static class Query
        {
            private const string _prefix = "LoanManagementModule.LoanApplication.Query";
            private const string _sqlScriptStem = "LoanApplication";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByApplicationNumber => ResourceKey($"{_sqlScriptStem}.GetByApplicationNumber.g.sql");
            public static string GetByCustomerId => ResourceKey($"{_sqlScriptStem}.GetByCustomerId.g.sql");
            public static string GetPendingReview => ResourceKey($"{_sqlScriptStem}.GetPendingReview.g.sql");
            public static string GetApplicationsWithProduct => ResourceKey($"{_sqlScriptStem}.GetApplicationsWithProduct.g.sql");
        }
    }
}