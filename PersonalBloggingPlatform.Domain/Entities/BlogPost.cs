using PersonalBloggingPlatform.Domain.Events;
using PersonalBloggingPlatform.Domain.Exceptions;
using PersonalBloggingPlatform.Domain.ValueObjects;
using PersonalBloggingPlatform.Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

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

    public void AddTag(Tag tag)
    {
        var alreadyExists = _tags.Contains(tag);

        if (alreadyExists)
        {
            throw new BlogPostTagAlreadyExistsException(_title, tag.Name);
        }

        _tags.AddLast(tag);
        AddEvent(new BlogPostTagAdded(this, tag));
    }

    public void RemoveTag(Tag Tag)
    {
        var tag = GetTag(Tag.Name);
        _tags.Remove(tag);
        AddEvent(new BlogPostTagRemoved(this, tag));
    }

    private Tag GetTag(string tagName)
    {
        var tag = _tags.SingleOrDefault(t => t.Name == tagName)
            ?? throw new BlogPostTagNotFoundException(tagName);

        return tag;
    }

    public void SetCategory(Category category)
    {
        _category = category;
        AddEvent(new BlogPostCategoryIsSet(this, category));
    }
}