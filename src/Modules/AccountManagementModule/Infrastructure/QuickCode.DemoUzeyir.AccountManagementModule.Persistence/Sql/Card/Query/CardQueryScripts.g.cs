namespace QuickCode.DemoUzeyir.AccountManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Card
    {
        public static class Query
        {
            private const string _prefix = "AccountManagementModule.Card.Query";
            private const string _sqlScriptStem = "Card";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByAccountId => ResourceKey($"{_sqlScriptStem}.GetByAccountId.g.sql");
            public static string GetCardsWithType => ResourceKey($"{_sqlScriptStem}.GetCardsWithType.g.sql");
            public static string GetExpiredCards => ResourceKey($"{_sqlScriptStem}.GetExpiredCards.g.sql");
        }
    }
}