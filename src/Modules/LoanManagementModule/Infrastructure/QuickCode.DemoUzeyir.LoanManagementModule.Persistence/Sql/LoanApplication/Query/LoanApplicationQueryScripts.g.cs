namespace QuickCode.DemoUzeyir.LoanManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class LoanApplication
    {
        public static class Query
        {
            private const string _prefix = "LoanManagementModule.LoanApplication.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByApplicationNumber => ResourceKey("GetByApplicationNumber.g.sql");
            public static string GetByCustomerId => ResourceKey("GetByCustomerId.g.sql");
            public static string GetPendingReview => ResourceKey("GetPendingReview.g.sql");
            public static string GetApplicationsWithProduct => ResourceKey("GetApplicationsWithProduct.g.sql");
        }
    }
}