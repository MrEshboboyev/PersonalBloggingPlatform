using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System;

namespace PersonalBloggingPlatform.Application.Commands;

public record RemoveBlogPostTag(Guid BlogPostId, string TagName) : ICommand;