namespace QuickCode.DemoUzeyir.LoanManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class LoanApplication
    {
        public static class Command
        {
            private const string _prefix = "LoanManagementModule.LoanApplication.Command";
            private const string _sqlScriptStem = "LoanApplication";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string SubmitApplication => ResourceKey($"{_sqlScriptStem}.SubmitApplication.g.sql");
            public static string ApproveApplication => ResourceKey($"{_sqlScriptStem}.ApproveApplication.g.sql");
            public static string RejectApplication => ResourceKey($"{_sqlScriptStem}.RejectApplication.g.sql");
            public static string WithdrawApplication => ResourceKey($"{_sqlScriptStem}.WithdrawApplication.g.sql");
        }
    }
}