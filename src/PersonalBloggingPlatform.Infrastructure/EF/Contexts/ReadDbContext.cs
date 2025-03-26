using Microsoft.EntityFrameworkCore;
using PersonalBloggingPlatform.Infrastructure.EF.Models;
using PersonalBloggingPlatform.Infrastructure.EF.Config;

namespace PersonalBloggingPlatform.Infrastructure.EF.Contexts;

public sealed class ReadDbContext(DbContextOptions<ReadDbContext> options) : DbContext(options)
{
    public DbSet<BlogPostReadModel> BlogPosts { get; set; }
    public DbSet<TagReadModel> Tags { get; set; }
    public DbSet<CategoryReadModel> Categories { get; set; }
    public DbSet<UserReadModel> Users { get; set; }
    public DbSet<RoleReadModel> Roles { get; set; }
    public DbSet<CommentReadModel> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("blogPost");

        // Apply Read-specific configurations
        var configuration = new ReadConfiguration();
        modelBuilder.ApplyConfiguration<BlogPostReadModel>(configuration);
        modelBuilder.ApplyConfiguration<TagReadModel>(configuration);
        modelBuilder.ApplyConfiguration<CategoryReadModel>(configuration);
        modelBuilder.ApplyConfiguration<UserReadModel>(configuration);
        modelBuilder.ApplyConfiguration<RoleReadModel>(configuration);
        modelBuilder.ApplyConfiguration<CommentReadModel>(configuration);

        base.OnModelCreating(modelBuilder);
    }
}
