using PersonalBloggingPlatform.Application.Exceptions;
using PersonalBloggingPlatform.Application.Services;
using PersonalBloggingPlatform.Domain.Factories;
using PersonalBloggingPlatform.Domain.Repositories;
using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Application.Commands.Handlers;

public class CreateBlogPostHandler(IBlogPostRepository blogPostRepository,
    ICategoryRepository categoryRepository,
    IBlogPostFactory factory,
    IBlogPostReadService readService) : ICommandHandler<CreateBlogPost>
{
    private readonly IBlogPostRepository _blogPostRepository = blogPostRepository;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IBlogPostFactory _factory = factory;
    private readonly IBlogPostReadService _readService = readService;

    public async Task HandleAsync(CreateBlogPost command)
    {
        var (title, content, categoryId) = command;

        if (await _readService.ExistsByTitleAsync(title))
        {
            throw new BlogPostAlreadyExistsException(title);
        }

        var category = await _categoryRepository.GetAsync(categoryId)
            ?? throw new CategoryNotFoundException(categoryId);

        var blogPost = _factory.Create(title, content, categoryId);

        await _blogPostRepository.CreateAsync(blogPost);
    }
}
