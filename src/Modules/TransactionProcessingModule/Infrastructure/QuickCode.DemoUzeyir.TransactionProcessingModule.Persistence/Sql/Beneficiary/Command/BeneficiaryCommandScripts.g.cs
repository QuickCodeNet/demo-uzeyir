namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Beneficiary
    {
        public static class Command
        {
            private const string _prefix = "TransactionProcessingModule.Beneficiary.Command";
            private const string _sqlScriptStem = "Beneficiary";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string Deactivate => ResourceKey($"{_sqlScriptStem}.Deactivate.g.sql");
        }
    }
}