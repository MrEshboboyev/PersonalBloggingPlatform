using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System;

namespace PersonalBloggingPlatform.Application.Commands;

public record ChangeBlogPostCategory(Guid BlogPostId, Guid NewCategoryId) : ICommand;