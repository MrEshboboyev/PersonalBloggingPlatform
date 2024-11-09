using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System;

namespace PersonalBloggingPlatform.Application.Commands;

public record class AddTagToBlogPost(Guid BlogPostId, Guid TagId) : ICommand;
