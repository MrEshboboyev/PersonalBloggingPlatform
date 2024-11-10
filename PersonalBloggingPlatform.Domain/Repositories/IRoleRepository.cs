using PersonalBloggingPlatform.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Domain.Repositories;

public interface IRoleRepository
{
    Task<User> GetByIdAsync(Guid id);
    Task AddAsync(Role role);
    Task UpdateAsync(Role role);
}