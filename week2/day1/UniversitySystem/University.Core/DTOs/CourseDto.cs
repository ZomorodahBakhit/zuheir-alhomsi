using System;
using System.Collections.Generic;
using System.Text;

namespace University.Core.DTOs;

public class CourseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int? TeacherId { get; set; }
    public  DateTime StartDate { get; set; }
    public  DateTime EndDate { get; set; }
    public int? SyllabusId { get; set; }
    }

