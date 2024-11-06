using PersonalBloggingPlatform.Domain.Entities;
using PersonalBloggingPlatform.Domain.ValueObjects;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Domain.Repositories;

public interface IBlogPostRepository
{
    Task<BlogPost> GetAsync(BlogPostId id);
    Task CreateAsync(BlogPost blogPost);
    Task UpdateAsync(BlogPost blogPost);
    Task DeleteAsync(BlogPost blogPost);
}
