namespace QuickCode.DemoUzeyir.AccountManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Account
    {
        public static class Command
        {
            private const string _prefix = "AccountManagementModule.Account.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string ApproveAccount => ResourceKey("ApproveAccount.g.sql");
            public static string FreezeAccount => ResourceKey("FreezeAccount.g.sql");
            public static string CloseAccount => ResourceKey("CloseAccount.g.sql");
            public static string UpdateBalance => ResourceKey("UpdateBalance.g.sql");
        }
    }
}