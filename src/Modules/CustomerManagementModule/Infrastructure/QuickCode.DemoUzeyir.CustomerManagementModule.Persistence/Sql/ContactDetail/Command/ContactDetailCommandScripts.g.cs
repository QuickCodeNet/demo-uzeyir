namespace QuickCode.DemoUzeyir.CustomerManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class ContactDetail
    {
        public static class Command
        {
            private const string _prefix = "CustomerManagementModule.ContactDetail.Command";
            private const string _sqlScriptStem = "ContactDetail";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string MarkAsVerified => ResourceKey($"{_sqlScriptStem}.MarkAsVerified.g.sql");
            public static string RemoveContact => ResourceKey($"{_sqlScriptStem}.RemoveContact.g.sql");
        }
    }
}