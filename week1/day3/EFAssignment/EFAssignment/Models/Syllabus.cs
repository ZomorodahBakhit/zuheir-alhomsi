namespace EFAssignment.Models;

public class Syllabus
{
    public int SyllabusId { get; set; }
    public string? Description { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;
}