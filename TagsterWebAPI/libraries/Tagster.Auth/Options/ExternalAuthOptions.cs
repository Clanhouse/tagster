namespace Tagster.Auth.Options;

public class ExternalAuthOptions
{
    public const string Name = "externalAuth";

    public class GoogleOptions
    {
        public string Audience { get; set; }
    }
    
    public GoogleOptions Google { get; set; }
}
