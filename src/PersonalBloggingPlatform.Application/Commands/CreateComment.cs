using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System;

namespace PersonalBloggingPlatform.Application.Commands;

public record class CreateComment(string Content, Guid UserId, Guid BlogPostId) : ICommand;