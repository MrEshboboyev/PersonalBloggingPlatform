using Microsoft.EntityFrameworkCore;
using PersonalBloggingPlatform.Domain.Entities;
using PersonalBloggingPlatform.Domain.Repositories;
using PersonalBloggingPlatform.Infrastructure.EF.Contexts;
using System.Threading.Tasks;
using System;

namespace PersonalBloggingPlatform.Infrastructure.EF.Repositories;

internal class PostgresUserRepository(WriteDbContext writeDbContext) : IUserRepository
{
    private readonly DbSet<User> _users = writeDbContext.Users;
    private readonly WriteDbContext _writeDbContext = writeDbContext;

    public Task<User> GetByIdAsync(Guid id)
        => _users.SingleOrDefaultAsync(t => t.Id == id);


    public Task<User> GetByUsernameAsync(string username)
        => _users.SingleOrDefaultAsync(t => t.Username == username);

    public async Task AddAsync(User user)
    {
        await _users.AddAsync(user);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _users.Update(user);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user)
    {
        _users.Remove(user);
        await _writeDbContext.SaveChangesAsync();
    }
}
