using Microsoft.EntityFrameworkCore;
using PersonalBloggingPlatform.Application.Services;
using PersonalBloggingPlatform.Infrastructure.EF.Contexts;
using PersonalBloggingPlatform.Infrastructure.EF.Models;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Infrastructure.EF.Services;

internal sealed class PostgresCategoryReadService(ReadDbContext readDbContext) : ICategoryReadService
{
    private readonly DbSet<CategoryReadModel> _categories = readDbContext.Categories;

    public Task<bool> ExistsByNameAsync(string name)
    {
        return _categories.AnyAsync(t => t.Name == name);
    }
}