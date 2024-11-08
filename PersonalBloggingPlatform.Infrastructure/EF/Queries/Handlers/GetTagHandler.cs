using Microsoft.EntityFrameworkCore;
using PersonalBloggingPlatform.Application.DTO;
using PersonalBloggingPlatform.Application.Queries;
using PersonalBloggingPlatform.Infrastructure.EF.Contexts;
using PersonalBloggingPlatform.Infrastructure.EF.Models;
using PersonalBloggingPlatform.Shared.Abstractions.Queries;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Infrastructure.EF.Queries.Handlers;

public class GetTagHandler(ReadDbContext context)
    : IQueryHandler<GetTag, TagDto>
{
    private readonly DbSet<TagReadModel> _tags = context.Tags;

    public Task<TagDto> HandleAsync(GetTag query)
        => _tags
            .Where(t => t.Id == query.Id)
            .Select(t => t.AsDto())
            .AsNoTracking()
            .SingleOrDefaultAsync();
}