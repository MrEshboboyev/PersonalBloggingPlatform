using Microsoft.EntityFrameworkCore;
using PersonalBloggingPlatform.Application.DTO;
using PersonalBloggingPlatform.Application.Queries;
using PersonalBloggingPlatform.Infrastructure.EF.Contexts;
using PersonalBloggingPlatform.Infrastructure.EF.Models;
using PersonalBloggingPlatform.Shared.Abstractions.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace PersonalBloggingPlatform.Infrastructure.EF.Queries.Handlers;

internal sealed class GetBlogPostsByTagHandler(ReadDbContext context)
    : IQueryHandler<GetBlogPostsByTag, IEnumerable<BlogPostDto>>
{
    private readonly DbSet<BlogPostReadModel> _blogPosts = context.BlogPosts;

    public async Task<IEnumerable<BlogPostDto>> HandleAsync(GetBlogPostsByTag query)
    {
        var dbQuery = _blogPosts
            .AsQueryable();

        var lowerTagName = query.TagName.ToLower();

        dbQuery = dbQuery.Where(bp => bp.Tags.Any(t => t.Name.Equals(lowerTagName, 
            StringComparison.CurrentCultureIgnoreCase)));

        return await dbQuery
            .Select(bp => bp.AsDto())
            .AsNoTracking()
            .ToListAsync();
    }
}