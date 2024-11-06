using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System;

namespace PersonalBloggingPlatform.Application.Commands;

public record CreateBlogPost(Guid Id, string Title, string Content) : ICommand;