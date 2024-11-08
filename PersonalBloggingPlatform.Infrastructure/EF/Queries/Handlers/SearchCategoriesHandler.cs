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

internal sealed class SearchCategoriesHandler(ReadDbContext context)
    : IQueryHandler<SearchCategories, IEnumerable<CategoryDto>>
{
    private readonly DbSet<CategoryReadModel> _categories = context.Categories;

    public async Task<IEnumerable<CategoryDto>> HandleAsync(SearchCategories query)
    {
        var dbQuery = _categories
            .AsQueryable();

        if (query.SearchPhrase is not null)
        {
            dbQuery = dbQuery.Where(t => 
                Microsoft.EntityFrameworkCore.EF.Functions.ILike(t.Name, $"%{query.SearchPhrase}%"));
        }

        return await dbQuery
            .Select(c => c.AsDto())
            .AsNoTracking()
            .ToListAsync();
    }
}

