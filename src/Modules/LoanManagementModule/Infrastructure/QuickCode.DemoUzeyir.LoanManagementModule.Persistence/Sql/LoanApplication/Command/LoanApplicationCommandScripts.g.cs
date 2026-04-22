namespace QuickCode.DemoUzeyir.LoanManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class LoanApplication
    {
        public static class Command
        {
            private const string _prefix = "LoanManagementModule.LoanApplication.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string SubmitApplication => ResourceKey("SubmitApplication.g.sql");
            public static string ApproveApplication => ResourceKey("ApproveApplication.g.sql");
            public static string RejectApplication => ResourceKey("RejectApplication.g.sql");
            public static string WithdrawApplication => ResourceKey("WithdrawApplication.g.sql");
        }
    }
}