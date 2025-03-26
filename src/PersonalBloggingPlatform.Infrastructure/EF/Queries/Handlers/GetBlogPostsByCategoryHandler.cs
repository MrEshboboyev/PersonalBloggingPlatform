using Microsoft.EntityFrameworkCore;
using PersonalBloggingPlatform.Application.DTO;
using PersonalBloggingPlatform.Application.Queries;
using PersonalBloggingPlatform.Infrastructure.EF.Contexts;
using PersonalBloggingPlatform.Infrastructure.EF.Models;
using PersonalBloggingPlatform.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Infrastructure.EF.Queries.Handlers;

internal sealed class GetBlogPostsByCategoryHandler(ReadDbContext context)
    : IQueryHandler<GetBlogPostsByCategory, IEnumerable<BlogPostDto>>
{
    private readonly DbSet<BlogPostReadModel> _blogPosts = context.BlogPosts;

    public async Task<IEnumerable<BlogPostDto>> HandleAsync(GetBlogPostsByCategory query)
    {
        var dbQuery = _blogPosts
            .AsQueryable();

        var lowerCategoryName = query.CategoryName.ToLower();

        dbQuery = dbQuery.Where(bp => bp.Category.Name.Equals(lowerCategoryName,
            StringComparison.CurrentCultureIgnoreCase));

        return await dbQuery
            .Select(bp => bp.AsDto())
            .AsNoTracking()
            .ToListAsync();
    }
}
