using PersonalBloggingPlatform.Domain.ValueObjects;
using PersonalBloggingPlatform.Shared.Abstractions.Domain;
using System;

namespace PersonalBloggingPlatform.Domain.Entities;

public class BlogPost : AggregateRoot<BlogPostId>
{
    public BlogPostId Id { get; private set; }
    private PostTitle _title;
    private PostContent _content;
    private DateTime _createdAt;
    private DateTime _lastModified;

    internal BlogPost(BlogPostId id, PostTitle title, PostContent content, 
        DateTime createdAt, DateTime lastModified)
    {
        Id = id;
        _title = title;
        _content = content;
        _createdAt = createdAt;
        _lastModified = lastModified;
    }
}

