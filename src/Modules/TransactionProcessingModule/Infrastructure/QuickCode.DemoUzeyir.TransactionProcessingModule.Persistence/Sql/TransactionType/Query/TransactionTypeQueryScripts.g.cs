namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class TransactionType
    {
        public static class Query
        {
            private const string _prefix = "TransactionProcessingModule.TransactionType.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetActive => ResourceKey("GetActive.g.sql");
            public static string GetByCode => ResourceKey("GetByCode.g.sql");
        }
    }
}