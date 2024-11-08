using PersonalBloggingPlatform.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Domain.Repositories;

public interface IBlogPostRepository
{
    Task<BlogPost> GetAsync(Guid id);
    Task CreateAsync(BlogPost blogPost);
    Task UpdateAsync(BlogPost blogPost);
    Task DeleteAsync(BlogPost blogPost);
}
