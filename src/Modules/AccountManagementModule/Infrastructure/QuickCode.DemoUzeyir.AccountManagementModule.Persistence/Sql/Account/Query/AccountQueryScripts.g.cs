namespace QuickCode.DemoUzeyir.AccountManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Account
    {
        public static class Query
        {
            private const string _prefix = "AccountManagementModule.Account.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByAccountNumber => ResourceKey("GetByAccountNumber.g.sql");
            public static string GetByCustomerId => ResourceKey("GetByCustomerId.g.sql");
            public static string GetAccountsWithDetails => ResourceKey("GetAccountsWithDetails.g.sql");
            public static string GetLowBalanceAccounts => ResourceKey("GetLowBalanceAccounts.g.sql");
            public static string GetDormantAccounts => ResourceKey("GetDormantAccounts.g.sql");
            public static string GetTotalBalanceByCustomer => ResourceKey("GetTotalBalanceByCustomer.g.sql");
        }
    }
}