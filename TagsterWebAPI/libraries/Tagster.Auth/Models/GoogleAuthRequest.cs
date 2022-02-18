using System.ComponentModel.DataAnnotations;

namespace Tagster.Auth.Models;

public class GoogleAuthRequest
{
    [Required]
    public string IdToken { get; set; }
}
