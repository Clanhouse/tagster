namespace Tagster.Infrastructure.EF.Options;

internal class DatabaseOption
{
    public const string Name = "database";
    public string ConectionString { get; set; }
    public string AdminPassword { get; set; }
    public string AdminEmail { get; set; }
}
