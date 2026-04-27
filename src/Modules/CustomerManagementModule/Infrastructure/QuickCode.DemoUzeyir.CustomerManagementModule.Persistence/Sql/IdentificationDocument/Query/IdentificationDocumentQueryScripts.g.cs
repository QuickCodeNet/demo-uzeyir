namespace QuickCode.DemoUzeyir.CustomerManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class IdentificationDocument
    {
        public static class Query
        {
            private const string _prefix = "CustomerManagementModule.IdentificationDocument.Query";
            private const string _sqlScriptStem = "IdentificationDocument";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByCustomerId => ResourceKey($"{_sqlScriptStem}.GetByCustomerId.g.sql");
            public static string GetDocumentsWithType => ResourceKey($"{_sqlScriptStem}.GetDocumentsWithType.g.sql");
            public static string GetExpiringSoon => ResourceKey($"{_sqlScriptStem}.GetExpiringSoon.g.sql");
        }
    }
}