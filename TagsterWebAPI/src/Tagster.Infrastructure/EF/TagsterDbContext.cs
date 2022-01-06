using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Tagster.Domain.Authorization;
using Tagster.Domain.Entities;
using Tagster.Infrastructure.EF.Options;

namespace Tagster.Infrastructure.EF;

internal class TagsterDbContext : DbContext
{
    private readonly IEnumerable<User> DefaultUsers;

    public DbSet<Tag> Tags { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    public TagsterDbContext(DbContextOptions options, DatabaseOption adminOptions) : base(options)
    {
        DefaultUsers = CreateDefaultUsers(adminOptions.AdminPassword, adminOptions.AdminEmail);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("tagster");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        modelBuilder.Entity<User>().HasData(DefaultUsers);
    }

    private static IEnumerable<User> CreateDefaultUsers(string adminPassword, string adminEmail) 
        => new List<User>()
        {
            new (0,adminEmail, adminPassword, DateTime.UtcNow, Role.Admin),
        };
}
