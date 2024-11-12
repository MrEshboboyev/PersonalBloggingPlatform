using Microsoft.EntityFrameworkCore;
using PersonalBloggingPlatform.Domain.Entities;
using PersonalBloggingPlatform.Domain.Repositories;
using PersonalBloggingPlatform.Infrastructure.EF.Contexts;
using System;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Infrastructure.EF.Repositories;

internal sealed class PostgresBlogPostRepository(WriteDbContext writeDbContext) : IBlogPostRepository
{
    private readonly DbSet<BlogPost> _blogPosts = writeDbContext.BlogPosts;
    private readonly WriteDbContext _writeDbContext = writeDbContext;

    public Task<BlogPost> GetAsync(Guid id)
        => _blogPosts
            .Include(bp => bp.Tags)
            .Include(bp => bp.Comments)
            .SingleOrDefaultAsync(bp => bp.Id == id);

    public async Task CreateAsync(BlogPost blogPost)
    {
        await _blogPosts.AddAsync(blogPost);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(BlogPost blogPost)
    {
        _blogPosts.Update(blogPost);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(BlogPost blogPost)
    {
        _blogPosts.Remove(blogPost);
        await _writeDbContext.SaveChangesAsync();
    }
}