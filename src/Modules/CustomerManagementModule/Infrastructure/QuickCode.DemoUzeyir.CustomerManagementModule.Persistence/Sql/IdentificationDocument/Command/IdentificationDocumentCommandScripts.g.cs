namespace QuickCode.DemoUzeyir.CustomerManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class IdentificationDocument
    {
        public static class Command
        {
            private const string _prefix = "CustomerManagementModule.IdentificationDocument.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string VerifyDocument => ResourceKey("VerifyDocument.g.sql");
            public static string RejectDocument => ResourceKey("RejectDocument.g.sql");
            public static string MarkAsExpired => ResourceKey("MarkAsExpired.g.sql");
        }
    }
}