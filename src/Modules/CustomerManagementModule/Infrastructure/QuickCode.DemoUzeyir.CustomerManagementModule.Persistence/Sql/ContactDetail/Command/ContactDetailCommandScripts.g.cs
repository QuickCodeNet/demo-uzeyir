namespace QuickCode.DemoUzeyir.CustomerManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class ContactDetail
    {
        public static class Command
        {
            private const string _prefix = "CustomerManagementModule.ContactDetail.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string MarkAsVerified => ResourceKey("MarkAsVerified.g.sql");
            public static string RemoveContact => ResourceKey("RemoveContact.g.sql");
        }
    }
}