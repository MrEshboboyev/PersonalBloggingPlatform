using Microsoft.EntityFrameworkCore;
using PersonalBloggingPlatform.Application.Services;
using PersonalBloggingPlatform.Infrastructure.EF.Contexts;
using PersonalBloggingPlatform.Infrastructure.EF.Models;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Infrastructure.EF.Services;

internal sealed class PostgresBlogPostReadService(ReadDbContext readDbContext) : IBlogPostReadService
{
    private readonly DbSet<BlogPostReadModel> _blogPosts = readDbContext.BlogPosts;

    public Task<bool> ExistsByTitleAsync(string title)
    {
        return _blogPosts.AnyAsync(bp => bp.Title == title);
    }
}

