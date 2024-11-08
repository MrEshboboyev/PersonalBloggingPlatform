using Microsoft.EntityFrameworkCore;
using PersonalBloggingPlatform.Domain.Entities;
using PersonalBloggingPlatform.Domain.Repositories;
using PersonalBloggingPlatform.Infrastructure.EF.Contexts;
using System;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Infrastructure.EF.Repositories;

internal class PostgresCategoryRepository(WriteDbContext writeDbContext) : ICategoryRepository
{
    private readonly DbSet<Category> _categorys = writeDbContext.Categories;
    private readonly WriteDbContext _writeDbContext = writeDbContext;

    public Task<Category> GetAsync(Guid id)
        => _categorys.SingleOrDefaultAsync(t => t.Id == id);

    public async Task CreateAsync(Category category)
    {
        await _categorys.AddAsync(category);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Category category)
    {
        _categorys.Update(category);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Category category)
    {
        _categorys.Remove(category);
        await _writeDbContext.SaveChangesAsync();
    }
}
