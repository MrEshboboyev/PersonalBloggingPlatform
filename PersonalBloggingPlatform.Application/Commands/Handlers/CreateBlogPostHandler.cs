using PersonalBloggingPlatform.Application.Exceptions;
using PersonalBloggingPlatform.Application.Services;
using PersonalBloggingPlatform.Domain.Factories;
using PersonalBloggingPlatform.Domain.Repositories;
using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Application.Commands.Handlers;

public class CreateBlogPostHandler(IBlogPostRepository repository,
    IBlogPostFactory factory,
    IBlogPostReadService readService) : ICommandHandler<CreateBlogPost>
{
    private readonly IBlogPostRepository _repository = repository;
    private readonly IBlogPostFactory _factory = factory;
    private readonly IBlogPostReadService _readService = readService;

    public async Task HandleAsync(CreateBlogPost command)
    {
        var (title, content) = command;

        if (await _readService.ExistsByTitleAsync(title))
        {
            throw new BlogPostAlreadyExistsException(title);
        }

        var blogPost = _factory.Create(title, content);

        await _repository.CreateAsync(blogPost);
    }
}
