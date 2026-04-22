namespace QuickCode.DemoUzeyir.CustomerManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Customer
    {
        public static class Command
        {
            private const string _prefix = "CustomerManagementModule.Customer.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string ActivateCustomer => ResourceKey("ActivateCustomer.g.sql");
            public static string SuspendCustomer => ResourceKey("SuspendCustomer.g.sql");
            public static string CloseCustomer => ResourceKey("CloseCustomer.g.sql");
        }
    }
}