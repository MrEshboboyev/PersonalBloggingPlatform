using Microsoft.EntityFrameworkCore;
using PersonalBloggingPlatform.Infrastructure.EF.Models;

namespace PersonalBloggingPlatform.Infrastructure.EF.Contexts;

internal sealed class ReadDbContext(DbContextOptions<ReadDbContext> options) : DbContext(options)
{
    public DbSet<BlogPostReadModel> BlogPosts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("blogPost");
        base.OnModelCreating(modelBuilder);
    }
}
