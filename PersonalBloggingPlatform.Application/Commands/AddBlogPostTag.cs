using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System;

namespace PersonalBloggingPlatform.Application.Commands;

public record AddBlogPostTag(Guid BlogPostId, string TagName) : ICommand;