namespace QuickCode.DemoUzeyir.CustomerManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class CustomerRelationship
    {
        public static class Query
        {
            private const string _prefix = "CustomerManagementModule.CustomerRelationship.Query";
            private const string _sqlScriptStem = "CustomerRelationship";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetRelationshipsByCustomerId => ResourceKey($"{_sqlScriptStem}.GetRelationshipsByCustomerId.g.sql");
            public static string GetRelatedCustomers => ResourceKey($"{_sqlScriptStem}.GetRelatedCustomers.g.sql");
        }
    }
}