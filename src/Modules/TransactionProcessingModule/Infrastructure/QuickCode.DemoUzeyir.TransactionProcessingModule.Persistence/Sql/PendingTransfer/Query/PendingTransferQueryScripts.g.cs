namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class PendingTransfer
    {
        public static class Query
        {
            private const string _prefix = "TransactionProcessingModule.PendingTransfer.Query";
            private const string _sqlScriptStem = "PendingTransfer";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetScheduledTransfers => ResourceKey($"{_sqlScriptStem}.GetScheduledTransfers.g.sql");
            public static string GetPendingApproval => ResourceKey($"{_sqlScriptStem}.GetPendingApproval.g.sql");
            public static string GetBySourceAccount => ResourceKey($"{_sqlScriptStem}.GetBySourceAccount.g.sql");
        }
    }
}