namespace QuickCode.DemoUzeyir.CustomerManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class IdentificationDocument
    {
        public static class Command
        {
            private const string _prefix = "CustomerManagementModule.IdentificationDocument.Command";
            private const string _sqlScriptStem = "IdentificationDocument";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string VerifyDocument => ResourceKey($"{_sqlScriptStem}.VerifyDocument.g.sql");
            public static string RejectDocument => ResourceKey($"{_sqlScriptStem}.RejectDocument.g.sql");
            public static string MarkAsExpired => ResourceKey($"{_sqlScriptStem}.MarkAsExpired.g.sql");
        }
    }
}