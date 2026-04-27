namespace QuickCode.DemoUzeyir.CustomerManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class CustomerRelationship
    {
        public static class Command
        {
            private const string _prefix = "CustomerManagementModule.CustomerRelationship.Command";
            private const string _sqlScriptStem = "CustomerRelationship";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string RemoveRelationship => ResourceKey($"{_sqlScriptStem}.RemoveRelationship.g.sql");
        }
    }
}