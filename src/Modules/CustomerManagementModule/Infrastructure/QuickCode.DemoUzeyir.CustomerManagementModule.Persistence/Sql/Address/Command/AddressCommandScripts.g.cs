namespace QuickCode.DemoUzeyir.CustomerManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Address
    {
        public static class Command
        {
            private const string _prefix = "CustomerManagementModule.Address.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string SetAsPrimary => ResourceKey("SetAsPrimary.g.sql");
            public static string UnsetPrimary => ResourceKey("UnsetPrimary.g.sql");
            public static string RemoveAddress => ResourceKey("RemoveAddress.g.sql");
        }
    }
}