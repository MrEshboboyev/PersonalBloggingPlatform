using Microsoft.EntityFrameworkCore;
using PersonalBloggingPlatform.Domain.Entities;
using PersonalBloggingPlatform.Domain.Repositories;
using PersonalBloggingPlatform.Infrastructure.EF.Contexts;
using System;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Infrastructure.EF.Repositories;

internal class PostgresTagRepository(WriteDbContext writeDbContext) : ITagRepository
{
    private readonly DbSet<Tag> _tags = writeDbContext.Tags;
    private readonly WriteDbContext _writeDbContext = writeDbContext;

    public Task<Tag> GetAsync(Guid id)
        => _tags.SingleOrDefaultAsync(t => t.Id == id);

    public async Task CreateAsync(Tag tag)
    {
        await _tags.AddAsync(tag);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Tag tag)
    {
        _tags.Update(tag);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Tag tag)
    {
        _tags.Remove(tag);
        await _writeDbContext.SaveChangesAsync();
    }
}
