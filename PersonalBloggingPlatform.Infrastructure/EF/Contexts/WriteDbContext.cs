using Microsoft.EntityFrameworkCore;
using PersonalBloggingPlatform.Domain.Entities;
using PersonalBloggingPlatform.Domain.ValueObjects;
using PersonalBloggingPlatform.Infrastructure.EF.Config;

namespace PersonalBloggingPlatform.Infrastructure.EF.Contexts;

internal sealed class WriteDbContext(DbContextOptions<WriteDbContext> options) : DbContext(options)
{
    public DbSet<BlogPost> BlogPosts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("blogPost");

        var configuration = new WriteConfiguration();
        modelBuilder.ApplyConfiguration<BlogPost>(configuration);
        modelBuilder.ApplyConfiguration<Tag>(configuration);
        modelBuilder.ApplyConfiguration<Category>(configuration);
    }
}
