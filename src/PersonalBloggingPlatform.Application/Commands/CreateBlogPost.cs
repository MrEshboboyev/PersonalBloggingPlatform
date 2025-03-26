using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System;

namespace PersonalBloggingPlatform.Application.Commands;

public record CreateBlogPost(string Title, string Content, Guid CategoryId) : ICommand;