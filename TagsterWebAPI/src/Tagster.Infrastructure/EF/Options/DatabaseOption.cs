namespace Tagster.Infrastructure.EF.Options
{
    internal class DatabaseOption
    {
        public const string Name = "database";

        public DatabaseType Type { get; set; }
        public string ConectionString { get; set; }
    }
}
