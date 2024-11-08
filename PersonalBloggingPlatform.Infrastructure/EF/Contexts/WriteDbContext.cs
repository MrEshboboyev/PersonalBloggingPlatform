using Microsoft.EntityFrameworkCore;
using PersonalBloggingPlatform.Domain.Entities;
using PersonalBloggingPlatform.Infrastructure.EF.Config;

namespace PersonalBloggingPlatform.Infrastructure.EF.Contexts;

internal sealed class WriteDbContext(DbContextOptions<WriteDbContext> options) : DbContext(options)
{
    public DbSet<BlogPost> BlogPosts { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("blogPost");

        // Apply Write-specific configurations
        var configuration = new WriteConfiguration();
        modelBuilder.ApplyConfiguration<BlogPost>(configuration);
        modelBuilder.ApplyConfiguration<Tag>(configuration);
        modelBuilder.ApplyConfiguration<Category>(configuration);

        base.OnModelCreating(modelBuilder);
    }
}
