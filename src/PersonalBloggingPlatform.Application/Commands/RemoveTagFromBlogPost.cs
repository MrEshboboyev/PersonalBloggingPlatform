using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System;

namespace PersonalBloggingPlatform.Application.Commands;

public record RemoveTagFromBlogPost(Guid BlogPostId, Guid TagId) : ICommand;