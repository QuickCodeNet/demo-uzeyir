namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class PendingTransfer
    {
        public static class Command
        {
            private const string _prefix = "TransactionProcessingModule.PendingTransfer.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string ApproveTransfer => ResourceKey("ApproveTransfer.g.sql");
            public static string RejectTransfer => ResourceKey("RejectTransfer.g.sql");
            public static string CancelScheduledTransfer => ResourceKey("CancelScheduledTransfer.g.sql");
        }
    }
}