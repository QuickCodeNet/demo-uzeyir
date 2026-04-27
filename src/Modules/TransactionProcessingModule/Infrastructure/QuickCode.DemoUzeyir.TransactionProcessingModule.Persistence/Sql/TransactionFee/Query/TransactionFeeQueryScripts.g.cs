namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class TransactionFee
    {
        public static class Query
        {
            private const string _prefix = "TransactionProcessingModule.TransactionFee.Query";
            private const string _sqlScriptStem = "TransactionFee";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetFeesByTransactionId => ResourceKey($"{_sqlScriptStem}.GetFeesByTransactionId.g.sql");
            public static string GetFeesWithDetails => ResourceKey($"{_sqlScriptStem}.GetFeesWithDetails.g.sql");
            public static string GetTotalFeesByType => ResourceKey($"{_sqlScriptStem}.GetTotalFeesByType.g.sql");
        }
    }
}