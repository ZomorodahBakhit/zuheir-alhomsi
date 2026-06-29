using System;
using System.Collections.Generic;
using System.Text;

namespace University.Data.Entities;

public class Course
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int? TeacherId { get; set; }
    public required DateTime StartDate { get; set; } 
    public required DateTime EndDate { get; set; }
    public int? SyllabusId { get; set; }
}
