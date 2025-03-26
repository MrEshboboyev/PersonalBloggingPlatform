using PersonalBloggingPlatform.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Domain.Repositories;

public interface IUserRepository
{
    Task<User> GetByIdAsync(Guid id);
    Task<User> GetByUsernameAsync(string username);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
}