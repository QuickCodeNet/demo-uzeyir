namespace QuickCode.DemoUzeyir.AccountManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class CardType
    {
        public static class Query
        {
            private const string _prefix = "AccountManagementModule.CardType.Query";
            private const string _sqlScriptStem = "CardType";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetActive => ResourceKey($"{_sqlScriptStem}.GetActive.g.sql");
            public static string GetByCode => ResourceKey($"{_sqlScriptStem}.GetByCode.g.sql");
        }
    }
}