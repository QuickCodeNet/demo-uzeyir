namespace QuickCode.DemoUzeyir.CustomerManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class CustomerRelationship
    {
        public static class Command
        {
            private const string _prefix = "CustomerManagementModule.CustomerRelationship.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string RemoveRelationship => ResourceKey("RemoveRelationship.g.sql");
        }
    }
}