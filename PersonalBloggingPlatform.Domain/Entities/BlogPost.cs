using PersonalBloggingPlatform.Domain.Events;
using PersonalBloggingPlatform.Domain.ValueObjects;
using PersonalBloggingPlatform.Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;

namespace PersonalBloggingPlatform.Domain.Entities;

public class BlogPost : AggregateRoot<BlogPostId>
{
    public BlogPostId Id { get; private set; }
    private PostTitle _title;
    private PostContent _content;
    private DateTime _createdAt;
    private DateTime _lastModified;

    private readonly LinkedList<Tag> _tags = new();
    private Category _category;

    internal BlogPost(BlogPostId id, PostTitle title, PostContent content, 
        DateTime createdAt, DateTime lastModified)
    {
        Id = id;
        _title = title;
        _content = content;
        _createdAt = createdAt;
        _lastModified = lastModified;
    }

    public void UpdateContent(PostContent newContent)
    {
        _content = newContent;
        _lastModified = DateTime.UtcNow;
        AddEvent(new BlogPostUpdated(this));
    }

    public void UpdateTitle(PostTitle newTitle)
    {
        _title = newTitle;
        _lastModified = DateTime.UtcNow;
        AddEvent(new BlogPostUpdated(this));
    }

    public void Delete()
    {
        AddEvent(new BlogPostDeleted(Id));
    }
}

