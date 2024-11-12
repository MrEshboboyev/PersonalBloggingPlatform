using Microsoft.EntityFrameworkCore;
using PersonalBloggingPlatform.Domain.Entities;
using PersonalBloggingPlatform.Domain.Repositories;
using PersonalBloggingPlatform.Infrastructure.EF.Contexts;
using System;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Infrastructure.EF.Repositories;

internal class PostgresCommentRepository(WriteDbContext writeDbContext) : ICommentRepository
{
    private readonly DbSet<Comment> _comments = writeDbContext.Comments;
    private readonly WriteDbContext _writeDbContext = writeDbContext;

    public Task<Comment> GetAsync(Guid id)
        => _comments.SingleOrDefaultAsync(t => t.Id == id);

    public async Task CreateAsync(Comment comment)
    {
        await _comments.AddAsync(comment);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Comment comment)
    {
        _comments.Update(comment);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Comment comment)
    {
        _comments.Remove(comment);
        await _writeDbContext.SaveChangesAsync();
    }
}
