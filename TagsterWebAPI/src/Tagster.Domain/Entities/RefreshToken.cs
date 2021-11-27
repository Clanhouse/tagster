using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tagster.Domain.Entities
{
    [Table("RefreshTokens")]
    public class RefreshToken
    {
        [Key]
        public int Id { get; private set; }
        public string Token { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? RevokedAt { get; private set; }
        public int UserId { get; set; }

        public RefreshToken(string token, DateTime createdAt,
           int userId, DateTime? revokedAt = null)
        {
            Token = token;
            CreatedAt = createdAt;
            RevokedAt = revokedAt;
            UserId = userId;
        }

        public RefreshToken(int id, string token, DateTime createdAt,
          int userId, DateTime? revokedAt = null) : this(token, createdAt, userId, revokedAt)
            => Id = id;
    }
}
