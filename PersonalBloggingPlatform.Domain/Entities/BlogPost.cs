using PersonalBloggingPlatform.Domain.ValueObjects;
using System;

namespace PersonalBloggingPlatform.Domain.Entities;

public class BlogPost
{
    public Guid Id { get; private set; }
    private PostTitle _title;
    private PostContent _content;
    private DateTime _createdAt;
    private DateTime _lastModified;

    internal BlogPost(Guid id, PostTitle title, PostContent content, 
        DateTime createdAt, DateTime lastModified)
    {
        Id = id;
        _title = title;
        _content = content;
        _createdAt = createdAt;
        _lastModified = lastModified;
    }
}

