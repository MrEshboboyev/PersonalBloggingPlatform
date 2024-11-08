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

internal sealed class SearchTagsHandler(ReadDbContext context)
    : IQueryHandler<SearchTags, IEnumerable<TagDto>>
{
    private readonly DbSet<TagReadModel> _tags = context.Tags;

    public async Task<IEnumerable<TagDto>> HandleAsync(SearchTags query)
    {
        var dbQuery = _tags
            .AsQueryable();

        if (query.SearchPhrase is not null)
        {
            dbQuery = dbQuery.Where(t => 
                Microsoft.EntityFrameworkCore.EF.Functions.ILike(t.Name, $"%{query.SearchPhrase}%"));
        }

        return await dbQuery
            .Select(t => t.AsDto())
            .AsNoTracking()
            .ToListAsync();
    }
}

