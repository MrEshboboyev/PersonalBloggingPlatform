using PersonalBloggingPlatform.Domain.Entities;
using System.Threading.Tasks;
using System;

namespace PersonalBloggingPlatform.Domain.Repositories;

public interface ICategoryRepository
{
    Task<Category> GetAsync(Guid id);
    Task CreateAsync(Category category);
    Task UpdateAsync(Category category);
}