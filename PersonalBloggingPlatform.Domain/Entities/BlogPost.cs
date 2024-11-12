using PersonalBloggingPlatform.Domain.Events;
using PersonalBloggingPlatform.Domain.Exceptions;
using PersonalBloggingPlatform.Domain.ValueObjects;
using PersonalBloggingPlatform.Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonalBloggingPlatform.Domain.Entities;

public class BlogPost : AggregateRoot<Guid>
{
    private PostTitle _title;
    private PostContent _content;
    private readonly DateTime _createdAt;
    private DateTime _lastModified;

    private readonly List<Tag> _tags = [];
    private CategoryId _categoryId;
    private readonly List<Comment> _comments = [];

    // Public getters for properties
    public PostTitle Title => _title;
    public PostContent Content => _content;
    public DateTime CreatedAt => _createdAt;
    public DateTime LastModified => _lastModified;
    public IReadOnlyCollection<Tag> Tags => _tags.AsReadOnly();
    public CategoryId CategoryId => _categoryId;
    public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();

    // Private constructor for ORM support
    private BlogPost() { }

    internal BlogPost(PostTitle title, PostContent content, CategoryId categoryId,
        DateTime createdAt, DateTime lastModified)
    {
        Id = Guid.NewGuid();
        _title = title;
        _content = content;
        _categoryId = categoryId;
        _createdAt = createdAt;
        _lastModified = lastModified;

        // Raise the BlogPostCreated event
        AddEvent(new BlogPostCreated(this));
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

    #region Tag
    public void AddTag(Tag tag)
    {
        var alreadyExists = _tags.Contains(tag);

        if (alreadyExists)
        {
            throw new BlogPostTagAlreadyExistsException(_title, tag.Name);
        }

        _tags.Add(tag);
        AddEvent(new TagAddedToBlogPost(this, tag));
    }

    public void RemoveTag(Tag Tag)
    {
        var tag = GetTag(Tag.Name);
        _tags.Remove(tag);
        AddEvent(new TagRemovedFromBlogPost(this, tag));
    }

    private Tag GetTag(string tagName)
    {
        var tag = _tags.SingleOrDefault(t => t.Name == tagName)
            ?? throw new BlogPostTagNotFoundException(tagName);

        return tag;
    }
    #endregion

    #region Category
    public void ChangeCategory(CategoryId categoryId)
    {
        _categoryId = categoryId;
        AddEvent(new BlogPostCategoryChanged(this, categoryId));
    }
    #endregion
}