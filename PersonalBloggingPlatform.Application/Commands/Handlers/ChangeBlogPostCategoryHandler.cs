using PersonalBloggingPlatform.Application.Exceptions;
using PersonalBloggingPlatform.Domain.Repositories;
using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Application.Commands.Handlers;

public class ChangeBlogPostCategoryHandler(IBlogPostRepository blogPostRepository,
    ICategoryRepository categoryRepository) : ICommandHandler<ChangeBlogPostCategory>
{
    private readonly IBlogPostRepository _blogPostRepository = blogPostRepository;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task HandleAsync(ChangeBlogPostCategory command)
    {
        var (blogPostId, categoryId) = command;

        var blogPost = await _blogPostRepository.GetAsync(blogPostId)
            ?? throw new BlogPostNotFoundException(blogPostId);

        var category = await _categoryRepository.GetAsync(categoryId)
            ?? throw new CategoryNotFoundException(categoryId);

        blogPost.ChangeCategory(categoryId);

        await _blogPostRepository.UpdateAsync(blogPost);
    }
}