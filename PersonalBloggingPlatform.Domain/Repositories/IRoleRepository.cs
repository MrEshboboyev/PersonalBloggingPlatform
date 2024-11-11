using PersonalBloggingPlatform.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Domain.Repositories;

public interface IRoleRepository
{
    Task<Role> GetByIdAsync(Guid id);
    Task<Role> GetByNameAsync(string roleName);
    Task AddAsync(Role role);
    Task UpdateAsync(Role role);
}