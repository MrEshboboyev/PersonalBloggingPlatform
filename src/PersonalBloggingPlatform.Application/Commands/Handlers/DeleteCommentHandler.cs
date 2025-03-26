using PersonalBloggingPlatform.Application.Exceptions;
using PersonalBloggingPlatform.Domain.Repositories;
using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Application.Commands.Handlers;

public class DeleteCommentHandler(ICommentRepository commentRepository) : ICommandHandler<DeleteComment>
{
    private readonly ICommentRepository _commentRepository = commentRepository;

    public async Task HandleAsync(DeleteComment command)
    {
        var (userId, commentId) = command;

        var comment = await _commentRepository.GetAsync(commentId);

        if (comment is null || comment.UserId != userId)
        {
            throw new CommentNotFoundException(commentId);
        }

        await _commentRepository.DeleteAsync(comment);
    }
}