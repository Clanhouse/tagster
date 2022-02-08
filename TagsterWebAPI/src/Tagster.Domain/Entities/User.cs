using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tagster.Domain.Entities;

[Table("Users")]
public record User
{
    public int Id { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public string Role { get; private set; }

    public User(int id, string email, string password, DateTime createdAt, string role)
    {
        Id = id;
        Email = email;
        Password = password;
        CreatedAt = createdAt;
        Role = role;
    }
    
    public void ChangeRole(string role)
    {
        Role = role;
    }
}
