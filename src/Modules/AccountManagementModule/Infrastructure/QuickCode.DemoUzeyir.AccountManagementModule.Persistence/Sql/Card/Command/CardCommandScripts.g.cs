namespace QuickCode.DemoUzeyir.AccountManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Card
    {
        public static class Command
        {
            private const string _prefix = "AccountManagementModule.Card.Command";
            private const string _sqlScriptStem = "Card";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string ActivateCard => ResourceKey($"{_sqlScriptStem}.ActivateCard.g.sql");
            public static string BlockCard => ResourceKey($"{_sqlScriptStem}.BlockCard.g.sql");
            public static string ReportLostOrStolen => ResourceKey($"{_sqlScriptStem}.ReportLostOrStolen.g.sql");
        }
    }
}