using System;
using System.Collections.Generic;

namespace PersonalBloggingPlatform.Infrastructure.EF.Models;

public class CategoryReadModel(string name)
{
    public Guid Id { get; set; }
    public string Name { get; set; } = name;

    public ICollection<BlogPostReadModel> BlogPosts { get; set; }
}