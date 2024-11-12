using System;

namespace PersonalBloggingPlatform.API.Requests;

public class DeleteCommentRequest
{
    public Guid CommentId { get; set; }
}
