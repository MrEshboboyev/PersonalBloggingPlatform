using PersonalBloggingPlatform.Application.Exceptions;
using PersonalBloggingPlatform.Domain.Repositories;
using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Application.Commands.Handlers;

internal sealed class DeleteBlogPostHandler(IBlogPostRepository repository) 
    : ICommandHandler<DeleteBlogPost>
{
    private readonly IBlogPostRepository _repository = repository;

    public async Task HandleAsync(DeleteBlogPost command)
    {
        var blogPost = await _repository.GetAsync(command.Id)
            ?? throw new BlogPostNotFoundException(command.Id);
        await _repository.DeleteAsync(blogPost);
    }
}