namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Beneficiary
    {
        public static class Query
        {
            private const string _prefix = "TransactionProcessingModule.Beneficiary.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByCustomerId => ResourceKey("GetByCustomerId.g.sql");
            public static string SearchByNickname => ResourceKey("SearchByNickname.g.sql");
        }
    }
}