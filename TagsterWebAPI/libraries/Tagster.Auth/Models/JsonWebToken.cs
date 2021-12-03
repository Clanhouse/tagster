namespace Tagster.Auth.Models;

public class JsonWebToken
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public int Id { get; set; }
}
