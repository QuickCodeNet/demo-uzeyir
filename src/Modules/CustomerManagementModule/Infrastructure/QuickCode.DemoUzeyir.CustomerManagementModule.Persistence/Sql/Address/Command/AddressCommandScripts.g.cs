namespace QuickCode.DemoUzeyir.CustomerManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Address
    {
        public static class Command
        {
            private const string _prefix = "CustomerManagementModule.Address.Command";
            private const string _sqlScriptStem = "Address";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string SetAsPrimary => ResourceKey($"{_sqlScriptStem}.SetAsPrimary.g.sql");
            public static string UnsetPrimary => ResourceKey($"{_sqlScriptStem}.UnsetPrimary.g.sql");
            public static string RemoveAddress => ResourceKey($"{_sqlScriptStem}.RemoveAddress.g.sql");
        }
    }
}