using PersonalBloggingPlatform.Application.Exceptions;
using PersonalBloggingPlatform.Domain.Repositories;
using PersonalBloggingPlatform.Domain.ValueObjects;
using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Application.Commands.Handlers;

public class RemoveBlogPostTagHandler(IBlogPostRepository repository)
    : ICommandHandler<RemoveBlogPostTag>
{
    private readonly IBlogPostRepository _repository = repository;

    public async Task HandleAsync(RemoveBlogPostTag command)
    {
        var blogPost = await _repository.GetAsync(command.BlogPostId)
            ?? throw new BlogPostNotFoundException(command.BlogPostId);

        blogPost.RemoveTag(new Tag(command.TagName));
        await _repository.UpdateAsync(blogPost);
    }
}