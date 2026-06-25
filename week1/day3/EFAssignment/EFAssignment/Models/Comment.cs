namespace EFAssignment.Models;

public class Comment
{
    public int CommentId { get; set; }
    public int AssignmentId { get; set; }
    public int CreatedByUserId { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? CommentContent { get; set; }
    public Assignment Assignments { get; set; } = null!;
    public User User { get; set; } = null!;
}