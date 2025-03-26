using PersonalBloggingPlatform.Application.Exceptions;
using PersonalBloggingPlatform.Application.Services;
using PersonalBloggingPlatform.Domain.Repositories;
using PersonalBloggingPlatform.Domain.ValueObjects;
using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Application.Commands.Handlers;

internal class UpdateBlogPostHandler(IBlogPostRepository repository,
    IBlogPostReadService readService) : ICommandHandler<UpdateBlogPost>
{
    private readonly IBlogPostRepository _repository = repository;
    private readonly IBlogPostReadService _readService = readService;

    public async Task HandleAsync(UpdateBlogPost command)
    {
        var blogPost = await _repository.GetAsync(command.Id)
            ?? throw new BlogPostNotFoundException(command.Id);

        if (await _readService.ExistsByTitleAsync(command.Title))
        {
            throw new BlogPostAlreadyExistsException(command.Title);
        }

        blogPost.UpdateTitle(new PostTitle(command.Title));
        blogPost.UpdateContent(new PostContent(command.Content));
     
        await _repository.UpdateAsync(blogPost);
    }
}

