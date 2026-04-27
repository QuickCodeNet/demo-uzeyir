namespace QuickCode.DemoUzeyir.CustomerManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Customer
    {
        public static class Query
        {
            private const string _prefix = "CustomerManagementModule.Customer.Query";
            private const string _sqlScriptStem = "Customer";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByCustomerNumber => ResourceKey($"{_sqlScriptStem}.GetByCustomerNumber.g.sql");
            public static string SearchByName => ResourceKey($"{_sqlScriptStem}.SearchByName.g.sql");
            public static string GetActiveCustomers => ResourceKey($"{_sqlScriptStem}.GetActiveCustomers.g.sql");
            public static string GetCustomersByType => ResourceKey($"{_sqlScriptStem}.GetCustomersByType.g.sql");
            public static string GetRecentlyJoined => ResourceKey($"{_sqlScriptStem}.GetRecentlyJoined.g.sql");
            public static string GetActiveCountByType => ResourceKey($"{_sqlScriptStem}.GetActiveCountByType.g.sql");
        }
    }
}