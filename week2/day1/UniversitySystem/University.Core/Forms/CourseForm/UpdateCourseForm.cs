using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace University.Core.Forms.CourseForm;

public class UpdateCourseForm
{
    [Required(ErrorMessage = "Course Name is required")]
    [MinLength(2, ErrorMessage = "Course Name must be at least 2 characters")]
    public required string Name { get; set; }
    public int? TeacherId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int? SyllabusId { get; set; }
}
