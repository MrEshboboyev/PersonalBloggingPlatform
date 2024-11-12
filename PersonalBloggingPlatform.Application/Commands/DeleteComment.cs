using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System;

namespace PersonalBloggingPlatform.Application.Commands;

public record DeleteComment(Guid UserId, Guid CommentId) : ICommand;