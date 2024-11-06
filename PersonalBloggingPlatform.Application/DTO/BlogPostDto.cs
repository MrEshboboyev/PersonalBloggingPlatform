﻿using System;

namespace PersonalBloggingPlatform.Application.DTO;

public class BlogPostDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastModified { get; set; }
}