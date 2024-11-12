using PersonalBloggingPlatform.Domain.Entities;
using PersonalBloggingPlatform.Shared.Abstractions.Domain;

namespace PersonalBloggingPlatform.Domain.Events;

public record CommentAddedToBlogPost(BlogPost BlogPost, Comment Comment) : IDomainEvent;