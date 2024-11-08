using PersonalBloggingPlatform.Application.Exceptions;
using PersonalBloggingPlatform.Domain.Repositories;
using PersonalBloggingPlatform.Domain.ValueObjects;
using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Application.Commands.Handlers;

public class SetBlogPostCategoryHandler(IBlogPostRepository repository)
    : ICommandHandler<SetBlogPostCategory>
{
    private readonly IBlogPostRepository _repository = repository;

    public async Task HandleAsync(SetBlogPostCategory command)
    {
        var blogPost = await _repository.GetAsync(command.BlogPostId)
            ?? throw new BlogPostNotFoundException(command.BlogPostId);

        blogPost.SetCategory(new Category(command.CategoryName));
        await _repository.UpdateAsync(blogPost);
    }
}