using Microsoft.EntityFrameworkCore;
using PersonalBloggingPlatform.Domain.Entities;
using PersonalBloggingPlatform.Infrastructure.EF.Config;

namespace PersonalBloggingPlatform.Infrastructure.EF.Contexts;

internal sealed class WriteDbContext(DbContextOptions<WriteDbContext> options) : DbContext(options)
{
    public DbSet<BlogPost> BlogPosts { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("blogPost");

        // Apply Write-specific configurations
        var configuration = new WriteConfiguration();
        modelBuilder.ApplyConfiguration<BlogPost>(configuration);
        modelBuilder.ApplyConfiguration<Tag>(configuration);
        modelBuilder.ApplyConfiguration<Category>(configuration);
        modelBuilder.ApplyConfiguration<User>(configuration);
        modelBuilder.ApplyConfiguration<Role>(configuration);

        base.OnModelCreating(modelBuilder);
    }
}
