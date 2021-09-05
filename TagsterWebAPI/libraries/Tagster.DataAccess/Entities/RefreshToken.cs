using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tagster.DataAccess.Entities
{
    [Table("RefreshTokens")]
    public class RefreshToken
    {
        [Key]
        public int Id { get; private set; }
        public string Token { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? RevokedAt { get; private set; }

        public RefreshToken(int id, string token, DateTime createdAt,
           DateTime? revokedAt = null)
        {
            Id = id;
            Token = token;
            CreatedAt = createdAt;
            RevokedAt = revokedAt;
        }
    }
}
