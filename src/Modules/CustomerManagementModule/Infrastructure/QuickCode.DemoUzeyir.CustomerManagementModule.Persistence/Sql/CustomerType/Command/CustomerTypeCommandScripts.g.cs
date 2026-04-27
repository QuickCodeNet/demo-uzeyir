namespace QuickCode.DemoUzeyir.CustomerManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class CustomerType
    {
        public static class Command
        {
            private const string _prefix = "CustomerManagementModule.CustomerType.Command";
            private const string _sqlScriptStem = "CustomerType";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string Deactivate => ResourceKey($"{_sqlScriptStem}.Deactivate.g.sql");
        }
    }
}