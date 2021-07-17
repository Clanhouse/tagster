﻿using Microsoft.EntityFrameworkCore;
using Tagster.DataAccess.Entities;

namespace Tagster.DataAccess.DBContexts
{
    public class TagsterDbContext : DbContext, ITagsterDbContext
    {
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        public TagsterDbContext(DbContextOptions options) : base(options)
        {
                
        }
    }
}