using PersonalBloggingPlatform.Domain.Entities;
using PersonalBloggingPlatform.Shared.Abstractions.Domain;

namespace PersonalBloggingPlatform.Domain.Events;

public record CommentRemovedFromBlogPost(BlogPost BlogPost, Comment Comment) : IDomainEvent;

