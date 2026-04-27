namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Transaction
    {
        public static class Command
        {
            private const string _prefix = "TransactionProcessingModule.Transaction.Command";
            private const string _sqlScriptStem = "Transaction";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string CompleteTransaction => ResourceKey($"{_sqlScriptStem}.CompleteTransaction.g.sql");
            public static string FailTransaction => ResourceKey($"{_sqlScriptStem}.FailTransaction.g.sql");
            public static string ReverseTransaction => ResourceKey($"{_sqlScriptStem}.ReverseTransaction.g.sql");
        }
    }
}