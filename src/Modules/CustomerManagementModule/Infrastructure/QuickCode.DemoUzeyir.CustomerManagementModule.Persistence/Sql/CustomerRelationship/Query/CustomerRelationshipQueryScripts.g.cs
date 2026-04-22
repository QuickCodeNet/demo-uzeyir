namespace QuickCode.DemoUzeyir.CustomerManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class CustomerRelationship
    {
        public static class Query
        {
            private const string _prefix = "CustomerManagementModule.CustomerRelationship.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetRelationshipsByCustomerId => ResourceKey("GetRelationshipsByCustomerId.g.sql");
            public static string GetRelatedCustomers => ResourceKey("GetRelatedCustomers.g.sql");
        }
    }
}