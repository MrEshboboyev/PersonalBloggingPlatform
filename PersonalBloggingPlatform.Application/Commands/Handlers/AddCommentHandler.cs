using PersonalBloggingPlatform.Application.Exceptions;
using PersonalBloggingPlatform.Domain.Factories;
using PersonalBloggingPlatform.Domain.Repositories;
using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Application.Commands.Handlers;

public class AddCommentHandler(IBlogPostRepository blogPostRepository,
    ICommentFactory commentFactory) : ICommandHandler<AddComment>
{
    private readonly IBlogPostRepository _blogPostRepository = blogPostRepository;
    private readonly ICommentFactory _commentFactory = commentFactory;

    public async Task HandleAsync(AddComment command)
    {
        var (content, blogPostId, userId) = command;

        var blogPost = await _blogPostRepository.GetAsync(blogPostId)
            ?? throw new BlogPostNotFoundException(blogPostId);

        blogPost.AddComment(userId, content);

        await _blogPostRepository.UpdateAsync(blogPost);
    }
}