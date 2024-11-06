﻿using Microsoft.EntityFrameworkCore;
using PersonalBloggingPlatform.Domain.Entities;

namespace PersonalBloggingPlatform.Infrastructure.EF.Contexts;

internal sealed class WriteDbContext(DbContextOptions<ReadDbContext> options) : DbContext(options)
{
    public DbSet<BlogPost> BlogPosts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("blogPost");
        base.OnModelCreating(modelBuilder);
    }
}
