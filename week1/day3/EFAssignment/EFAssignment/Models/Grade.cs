using System.ComponentModel.DataAnnotations.Schema;

namespace EFAssignment.Models;

public class Grade
{
    public int GradeId { get; set; }
    public int AssignmentId { get; set; }
    public int StudentId { get; set; }
    public int? GradeVal { get; set; }
    public Assignment Assignment { get; set; } = null!;
    public User Student { get; set; } = null!;
}