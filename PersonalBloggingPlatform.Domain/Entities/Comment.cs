using PersonalBloggingPlatform.Domain.Events;
using PersonalBloggingPlatform.Domain.ValueObjects;
using PersonalBloggingPlatform.Shared.Abstractions.Domain;
using System;

namespace PersonalBloggingPlatform.Domain.Entities;

public class Comment : AggregateRoot<Guid>
{
    private CommentContent _content;
    private readonly DateTime _createdAt;
    private DateTime _lastModified;

    private Guid _userId;
    private Guid _blogPostId;

    // Public getters for properties
    public CommentContent Content => _content;
    public DateTime CreatedAt => _createdAt;
    public DateTime LastModified => _lastModified;
    public Guid UserId => _userId;
    public Guid BlogPostId => _blogPostId;

    // Private constructor for ORM support
    private Comment() { }

    internal Comment(CommentContent content, Guid userId, Guid blogPostId, DateTime lastModified)
    {
        Id = Guid.NewGuid();
        _content = content;
        _userId = userId;
        _blogPostId = blogPostId;
        _createdAt = DateTime.UtcNow;
        _lastModified = lastModified;

        // Raise the CommentCreated event
        AddEvent(new CommentCreated(this));
    }

    public void UpdateContent(CommentContent newContent)
    {
        _content = newContent;
        _lastModified = DateTime.UtcNow;
        AddEvent(new CommentUpdated(this));
    }
}