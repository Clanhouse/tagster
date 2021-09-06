using System;
using System.Text.Json.Serialization;

namespace Tagster.Auth.Dtos
{
    public class AuthDto
    {
<<<<<<< HEAD
        public Guid Id { get; set; }
=======
        public int Id { get; set; }
>>>>>>> e56f5e008b44f871bf3346eb31d0999174b491f7
        public string AccessToken { get; set; }
        [JsonIgnore]
        public string RefreshToken { get; set; }
    }
}
