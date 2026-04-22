namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class PendingTransfer
    {
        public static class Query
        {
            private const string _prefix = "TransactionProcessingModule.PendingTransfer.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetScheduledTransfers => ResourceKey("GetScheduledTransfers.g.sql");
            public static string GetPendingApproval => ResourceKey("GetPendingApproval.g.sql");
            public static string GetBySourceAccount => ResourceKey("GetBySourceAccount.g.sql");
        }
    }
}