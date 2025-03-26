using Microsoft.EntityFrameworkCore;
using PersonalBloggingPlatform.Application.DTO;
using PersonalBloggingPlatform.Application.Queries;
using PersonalBloggingPlatform.Infrastructure.EF.Contexts;
using PersonalBloggingPlatform.Infrastructure.EF.Models;
using PersonalBloggingPlatform.Shared.Abstractions.Queries;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Infrastructure.EF.Queries.Handlers;

public class GetCategoryHandler(ReadDbContext context)
    : IQueryHandler<GetCategory, CategoryDto>
{
    private readonly DbSet<CategoryReadModel> _categories = context.Categories;

    public Task<CategoryDto> HandleAsync(GetCategory query)
        => _categories
            .Where(c => c.Id == query.Id)
            .Select(c => c.AsDto())
            .AsNoTracking()
            .SingleOrDefaultAsync();
}