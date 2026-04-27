namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class FeeType
    {
        public static class Command
        {
            private const string _prefix = "TransactionProcessingModule.FeeType.Command";
            private const string _sqlScriptStem = "FeeType";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string Deactivate => ResourceKey($"{_sqlScriptStem}.Deactivate.g.sql");
        }
    }
}