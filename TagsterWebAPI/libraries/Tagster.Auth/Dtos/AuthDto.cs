using System.Text.Json.Serialization;

namespace Tagster.Auth.Dtos;

public class AuthDto
{
    public int Id { get; set; }
    public string AccessToken { get; set; }
    [JsonIgnore]
    public string RefreshToken { get; set; }
}
