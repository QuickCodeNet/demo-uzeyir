namespace QuickCode.DemoUzeyir.CustomerManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Customer
    {
        public static class Command
        {
            private const string _prefix = "CustomerManagementModule.Customer.Command";
            private const string _sqlScriptStem = "Customer";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string ActivateCustomer => ResourceKey($"{_sqlScriptStem}.ActivateCustomer.g.sql");
            public static string SuspendCustomer => ResourceKey($"{_sqlScriptStem}.SuspendCustomer.g.sql");
            public static string CloseCustomer => ResourceKey($"{_sqlScriptStem}.CloseCustomer.g.sql");
        }
    }
}