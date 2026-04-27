namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Transaction
    {
        public static class Query
        {
            private const string _prefix = "TransactionProcessingModule.Transaction.Query";
            private const string _sqlScriptStem = "Transaction";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByReference => ResourceKey($"{_sqlScriptStem}.GetByReference.g.sql");
            public static string GetBySourceAccount => ResourceKey($"{_sqlScriptStem}.GetBySourceAccount.g.sql");
            public static string GetByDestinationAccount => ResourceKey($"{_sqlScriptStem}.GetByDestinationAccount.g.sql");
            public static string GetByDateRange => ResourceKey($"{_sqlScriptStem}.GetByDateRange.g.sql");
            public static string GetTransactionsWithDetails => ResourceKey($"{_sqlScriptStem}.GetTransactionsWithDetails.g.sql");
            public static string GetFailedTransactions => ResourceKey($"{_sqlScriptStem}.GetFailedTransactions.g.sql");
            public static string GetDailyVolume => ResourceKey($"{_sqlScriptStem}.GetDailyVolume.g.sql");
        }
    }
}