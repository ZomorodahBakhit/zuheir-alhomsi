namespace EFAssignment.Models;

public class Assignment
{
    public int AssignmentId { get; set; }
    public int CourseId { get; set; }
    public required string AssignmentTitle { get; set; }
    public string? Description { get; set; }
    public double Weight { get; set; }
    public int MaxGrade { get; set; }
    public DateOnly DueDate { get; set; }
    public Course Course { get; set; } = null!;
    public ICollection<Comment> Comments { get; set; } = [];
    public ICollection<Grade> Grades { get; set; } = [];
}