using System;
using Tagster.Auth.Exceptions;

namespace Tagster.Auth.Models
{
    public class JsonWebRefreshToken
    {
        public Guid Id { get; set; }
<<<<<<< HEAD
        public Guid UserId { get; set; }
=======
        public int UserId { get; set; }
>>>>>>> e56f5e008b44f871bf3346eb31d0999174b491f7
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? RevokedAt { get; private set; }
        public bool Revoked => RevokedAt.HasValue;

<<<<<<< HEAD
        public JsonWebRefreshToken(Guid id, Guid userId, string token, DateTime expires, DateTime createdAt)
=======
        public JsonWebRefreshToken(Guid id, int userId, string token, DateTime expires, DateTime createdAt)
>>>>>>> e56f5e008b44f871bf3346eb31d0999174b491f7
        {
            Id = id;
            UserId = userId;
            Token = token;
            Expires = expires;
            CreatedAt = createdAt;
        }

        public void Revoke(DateTime revokedAt)
        {
            if (Revoked)
            {
                throw new RevokedRefreshTokenException();
            }

            RevokedAt = revokedAt;
        }
    }
}