using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Tagster.Auth.Services;
using Tagster.Domain.Authorization;
using Tagster.Domain.Entities;
using Tagster.Infrastructure.EF.Options;

namespace Tagster.Infrastructure.EF;

internal class TagsterDbContext : DbContext
{
    private readonly IEnumerable<User> DefaultUsers;
    private readonly IPasswordService _passwordService;

    public DbSet<Tag> Tags { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    public TagsterDbContext(DbContextOptions options, IPasswordService passwordService) : base(options)
    {
        _passwordService = passwordService;
        DefaultUsers = CreateDefaultUsers();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("tagster");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        modelBuilder.Entity<User>().HasData(DefaultUsers);
    }

    private IEnumerable<User> CreateDefaultUsers()
        => new List<User>()
        {
            new (1, "admin@admin.com", _passwordService.Hash("secret"), DateTime.UtcNow, Role.Admin),
        };
}
