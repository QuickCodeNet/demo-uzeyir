namespace QuickCode.DemoUzeyir.AccountManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Account
    {
        public static class Query
        {
            private const string _prefix = "AccountManagementModule.Account.Query";
            private const string _sqlScriptStem = "Account";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByAccountNumber => ResourceKey($"{_sqlScriptStem}.GetByAccountNumber.g.sql");
            public static string GetByCustomerId => ResourceKey($"{_sqlScriptStem}.GetByCustomerId.g.sql");
            public static string GetAccountsWithDetails => ResourceKey($"{_sqlScriptStem}.GetAccountsWithDetails.g.sql");
            public static string GetLowBalanceAccounts => ResourceKey($"{_sqlScriptStem}.GetLowBalanceAccounts.g.sql");
            public static string GetDormantAccounts => ResourceKey($"{_sqlScriptStem}.GetDormantAccounts.g.sql");
            public static string GetTotalBalanceByCustomer => ResourceKey($"{_sqlScriptStem}.GetTotalBalanceByCustomer.g.sql");
        }
    }
}