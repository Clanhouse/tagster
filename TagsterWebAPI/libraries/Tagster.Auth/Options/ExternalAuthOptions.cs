namespace Tagster.Auth.Options;

public class ExternalAuthOptions
{
    public const string Name = "externalAuth";

    public GoogleOptions Google { get; set; }
}
