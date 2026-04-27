namespace QuickCode.DemoUzeyir.AccountManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Account
    {
        public static class Command
        {
            private const string _prefix = "AccountManagementModule.Account.Command";
            private const string _sqlScriptStem = "Account";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string ApproveAccount => ResourceKey($"{_sqlScriptStem}.ApproveAccount.g.sql");
            public static string FreezeAccount => ResourceKey($"{_sqlScriptStem}.FreezeAccount.g.sql");
            public static string CloseAccount => ResourceKey($"{_sqlScriptStem}.CloseAccount.g.sql");
            public static string UpdateBalance => ResourceKey($"{_sqlScriptStem}.UpdateBalance.g.sql");
        }
    }
}