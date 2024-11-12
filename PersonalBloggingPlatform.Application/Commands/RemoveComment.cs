using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System;

namespace PersonalBloggingPlatform.Application.Commands;

public record RemoveComment(Guid BlogPostId, Guid UserId, Guid CommentId) : ICommand;