using Microsoft.EntityFrameworkCore;
using PersonalBloggingPlatform.Application.Services;
using PersonalBloggingPlatform.Infrastructure.EF.Contexts;
using PersonalBloggingPlatform.Infrastructure.EF.Models;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Infrastructure.EF.Services;

internal sealed class PostgresTagReadService(ReadDbContext readDbContext) : ITagReadService
{
    private readonly DbSet<TagReadModel> _tags = readDbContext.Tags;

    public Task<bool> ExistsByNameAsync(string name)
    {
        return _tags.AnyAsync(t => t.Name == name);
    }
}