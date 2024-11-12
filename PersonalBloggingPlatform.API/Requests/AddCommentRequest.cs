using System;

namespace PersonalBloggingPlatform.API.Requests;

public class AddCommentRequest
{
    public string Content { get; set; }
    public Guid BlogPostId { get; set; }
}
