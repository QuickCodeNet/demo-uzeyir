namespace QuickCode.DemoUzeyir.AccountManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class AccountType
    {
        public static class Command
        {
            private const string _prefix = "AccountManagementModule.AccountType.Command";
            private const string _sqlScriptStem = "AccountType";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string UpdateInterestRate => ResourceKey($"{_sqlScriptStem}.UpdateInterestRate.g.sql");
            public static string Deactivate => ResourceKey($"{_sqlScriptStem}.Deactivate.g.sql");
        }
    }
}