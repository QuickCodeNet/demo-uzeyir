namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Transaction
    {
        public static class Query
        {
            private const string _prefix = "TransactionProcessingModule.Transaction.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByReference => ResourceKey("GetByReference.g.sql");
            public static string GetBySourceAccount => ResourceKey("GetBySourceAccount.g.sql");
            public static string GetByDestinationAccount => ResourceKey("GetByDestinationAccount.g.sql");
            public static string GetByDateRange => ResourceKey("GetByDateRange.g.sql");
            public static string GetTransactionsWithDetails => ResourceKey("GetTransactionsWithDetails.g.sql");
            public static string GetFailedTransactions => ResourceKey("GetFailedTransactions.g.sql");
            public static string GetDailyVolume => ResourceKey("GetDailyVolume.g.sql");
        }
    }
}