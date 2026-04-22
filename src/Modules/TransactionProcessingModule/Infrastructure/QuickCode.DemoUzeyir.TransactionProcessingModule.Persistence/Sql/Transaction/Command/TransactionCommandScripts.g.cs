namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Transaction
    {
        public static class Command
        {
            private const string _prefix = "TransactionProcessingModule.Transaction.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string CompleteTransaction => ResourceKey("CompleteTransaction.g.sql");
            public static string FailTransaction => ResourceKey("FailTransaction.g.sql");
            public static string ReverseTransaction => ResourceKey("ReverseTransaction.g.sql");
        }
    }
}