using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System;

namespace PersonalBloggingPlatform.Application.Commands;

public record class AddComment(string Content, Guid UserId, Guid BlogPostId) : ICommand;