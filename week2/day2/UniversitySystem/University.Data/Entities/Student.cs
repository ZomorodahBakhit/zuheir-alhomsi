using System;
using System.Collections.Generic;
using System.Text;

namespace University.Data.Entities;

public class Student
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
}
