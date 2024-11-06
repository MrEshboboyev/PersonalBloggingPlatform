using PersonalBloggingPlatform.Application.DTO;
using PersonalBloggingPlatform.Domain.Repositories;
using PersonalBloggingPlatform.Shared.Abstractions.Queries;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Application.Queries.Handlers;

public class GetBlogPostHandler(IBlogPostRepository repository)
    : IQueryHandler<GetBlogPost, BlogPostDto>
{
    private readonly IBlogPostRepository _repository = repository;

    public async Task<BlogPostDto> HandleAsync(GetBlogPost query)
    {
        var blogPost = await _repository.GetAsync(query.Id);
        return blogPost?.AsDto();
    }
}