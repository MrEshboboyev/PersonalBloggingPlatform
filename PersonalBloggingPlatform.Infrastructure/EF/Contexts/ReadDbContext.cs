using Microsoft.EntityFrameworkCore;
using PersonalBloggingPlatform.Infrastructure.EF.Config;
using PersonalBloggingPlatform.Infrastructure.EF.Models;

namespace PersonalBloggingPlatform.Infrastructure.EF.Contexts;

public sealed class ReadDbContext(DbContextOptions<ReadDbContext> options) : DbContext(options)
{
    public DbSet<BlogPostReadModel> BlogPosts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("blogPost");

        var configuration = new ReadConfiguration();
        modelBuilder.ApplyConfiguration<BlogPostReadModel>(configuration);
        modelBuilder.ApplyConfiguration<TagReadModel>(configuration);
        modelBuilder.ApplyConfiguration<CategoryReadModel>(configuration);

        base.OnModelCreating(modelBuilder);
    }
}
