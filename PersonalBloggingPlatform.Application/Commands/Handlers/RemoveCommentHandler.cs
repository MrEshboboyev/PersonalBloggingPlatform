using PersonalBloggingPlatform.Application.Exceptions;
using PersonalBloggingPlatform.Domain.Repositories;
using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Application.Commands.Handlers;

public class RemoveCommentHandler(IBlogPostRepository blogPostRepository,
    ICommentRepository commentRepository) : ICommandHandler<RemoveComment>
{
    private readonly IBlogPostRepository _blogPostRepository = blogPostRepository;
    private readonly ICommentRepository _commentRepository = commentRepository;

    public async Task HandleAsync(RemoveComment command)
    {
        var (blogPostId, userId, commentId) = command;

        var blogPost = await _blogPostRepository.GetAsync(blogPostId)
            ?? throw new BlogPostNotFoundException(blogPostId);

        blogPost.RemoveComment(commentId, userId);

        await _blogPostRepository.UpdateAsync(blogPost);
    }
}