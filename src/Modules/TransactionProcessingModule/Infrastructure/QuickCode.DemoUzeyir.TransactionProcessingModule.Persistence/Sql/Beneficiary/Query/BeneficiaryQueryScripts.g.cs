namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Beneficiary
    {
        public static class Query
        {
            private const string _prefix = "TransactionProcessingModule.Beneficiary.Query";
            private const string _sqlScriptStem = "Beneficiary";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByCustomerId => ResourceKey($"{_sqlScriptStem}.GetByCustomerId.g.sql");
            public static string SearchByNickname => ResourceKey($"{_sqlScriptStem}.SearchByNickname.g.sql");
        }
    }
}