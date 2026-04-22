namespace QuickCode.DemoUzeyir.CustomerManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Customer
    {
        public static class Query
        {
            private const string _prefix = "CustomerManagementModule.Customer.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByCustomerNumber => ResourceKey("GetByCustomerNumber.g.sql");
            public static string SearchByName => ResourceKey("SearchByName.g.sql");
            public static string GetActiveCustomers => ResourceKey("GetActiveCustomers.g.sql");
            public static string GetCustomersByType => ResourceKey("GetCustomersByType.g.sql");
            public static string GetRecentlyJoined => ResourceKey("GetRecentlyJoined.g.sql");
            public static string GetActiveCountByType => ResourceKey("GetActiveCountByType.g.sql");
        }
    }
}