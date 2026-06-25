namespace EFAssignment.Models;

public class Course
{
    public int CourseId { get; set; }
    public required string CourseName { get; set; }
    public int? TeacherId { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public int? SyllabusId { get; set; }
    public User? Teacher { get; set; }
    public Syllabus? Syllabus { get; set; }
    public ICollection<Assignment> Assignments { get; set; }
        = [];
}
