using Microsoft.EntityFrameworkCore;
using PersonalBloggingPlatform.Domain.Entities;
using PersonalBloggingPlatform.Domain.Repositories;
using PersonalBloggingPlatform.Infrastructure.EF.Contexts;
using System.Threading.Tasks;
using System;

namespace PersonalBloggingPlatform.Infrastructure.EF.Repositories;

internal class PostgresRoleRepository(WriteDbContext writeDbContext) : IRoleRepository
{
    private readonly WriteDbContext _writeDbContext = writeDbContext;
    private readonly DbSet<Role> _roles = writeDbContext.Roles;

    public Task<Role> GetByIdAsync(Guid id)
        => _roles.SingleOrDefaultAsync(t => t.Id == id);


    public Task<Role> GetByNameAsync(string roleName)
        => _roles.SingleOrDefaultAsync(t => t.Name == roleName);

    public async Task AddAsync(Role role)
    {
        await _roles.AddAsync(role);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Role role)
    {
        _roles.Update(role);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Role role)
    {
        _roles.Remove(role);
        await _writeDbContext.SaveChangesAsync();
    }
}
