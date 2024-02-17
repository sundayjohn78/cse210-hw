using System;

public class Comment
{
    // Properties
    public string CommenterName { get; }
    public string CommentText { get; }

    // Constructor
    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}
