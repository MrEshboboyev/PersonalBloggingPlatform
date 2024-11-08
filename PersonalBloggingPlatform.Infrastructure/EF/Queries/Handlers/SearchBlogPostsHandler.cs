using Microsoft.EntityFrameworkCore;
using PersonalBloggingPlatform.Application.DTO;
using PersonalBloggingPlatform.Application.Queries;
using PersonalBloggingPlatform.Infrastructure.EF.Contexts;
using PersonalBloggingPlatform.Infrastructure.EF.Models;
using PersonalBloggingPlatform.Shared.Abstractions.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Infrastructure.EF.Queries.Handlers;

internal sealed class SearchBlogPostsHandler(ReadDbContext context)
    : IQueryHandler<SearchBlogPosts, IEnumerable<BlogPostDto>>
{
    private readonly DbSet<BlogPostReadModel> _blogPosts = context.BlogPosts;

    public async Task<IEnumerable<BlogPostDto>> HandleAsync(SearchBlogPosts query)
    {
        var dbQuery = _blogPosts
            .AsQueryable();

        if (query.SearchPhrase is not null)
        {
            dbQuery = dbQuery.Where(bp => 
                Microsoft.EntityFrameworkCore.EF.Functions.ILike(bp.Title, $"%{query.SearchPhrase}%"));
        }

        return await dbQuery
            .Include(bp => bp.Tags)
            .Include(bp => bp.Category)
            .Select(bp => bp.AsDto())
            .AsNoTracking()
            .ToListAsync();
    }
}

