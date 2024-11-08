using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System;

namespace PersonalBloggingPlatform.Application.Commands;

public record SetBlogPostCategory(Guid BlogPostId, string CategoryName) : ICommand;