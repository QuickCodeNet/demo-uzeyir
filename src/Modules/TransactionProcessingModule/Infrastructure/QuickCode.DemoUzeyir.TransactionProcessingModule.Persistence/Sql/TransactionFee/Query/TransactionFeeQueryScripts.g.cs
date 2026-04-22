namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class TransactionFee
    {
        public static class Query
        {
            private const string _prefix = "TransactionProcessingModule.TransactionFee.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetFeesByTransactionId => ResourceKey("GetFeesByTransactionId.g.sql");
            public static string GetFeesWithDetails => ResourceKey("GetFeesWithDetails.g.sql");
            public static string GetTotalFeesByType => ResourceKey("GetTotalFeesByType.g.sql");
        }
    }
}