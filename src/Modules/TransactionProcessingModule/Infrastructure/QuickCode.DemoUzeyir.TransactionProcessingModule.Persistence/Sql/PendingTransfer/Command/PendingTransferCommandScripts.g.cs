namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class PendingTransfer
    {
        public static class Command
        {
            private const string _prefix = "TransactionProcessingModule.PendingTransfer.Command";
            private const string _sqlScriptStem = "PendingTransfer";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string ApproveTransfer => ResourceKey($"{_sqlScriptStem}.ApproveTransfer.g.sql");
            public static string RejectTransfer => ResourceKey($"{_sqlScriptStem}.RejectTransfer.g.sql");
            public static string CancelScheduledTransfer => ResourceKey($"{_sqlScriptStem}.CancelScheduledTransfer.g.sql");
        }
    }
}