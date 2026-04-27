namespace QuickCode.DemoUzeyir.CustomerManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class ContactDetail
    {
        public static class Query
        {
            private const string _prefix = "CustomerManagementModule.ContactDetail.Query";
            private const string _sqlScriptStem = "ContactDetail";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByCustomerId => ResourceKey($"{_sqlScriptStem}.GetByCustomerId.g.sql");
            public static string GetUnverifiedContacts => ResourceKey($"{_sqlScriptStem}.GetUnverifiedContacts.g.sql");
        }
    }
}