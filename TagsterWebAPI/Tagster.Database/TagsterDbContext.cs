﻿using Microsoft.EntityFrameworkCore;

namespace Tagster.Database
{
    public class TagsterDbContext : DbContext
    {
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Profile> Profiles { get; set; }


        public TagsterDbContext(DbContextOptions options) : base(options)
        {
                
        }
    }
}