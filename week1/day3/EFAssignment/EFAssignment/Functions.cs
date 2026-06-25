using System;
using System.Collections.Generic;
using System.Text;

namespace EFAssignment;

public class Functions
{
    public static char CalculateGradeInCourse(int studentId, int courseId , UniversityDbContext context)
    {
        char letter = ' ';

        var finalGrade = context.Grade
            .Where(g =>
                g.StudentId == studentId &&
                g.Assignment.CourseId == courseId)
            .Sum(g => ((g.GradeVal ?? 0) / 100.0) * (double)g.Assignment.Weight);

        if (finalGrade >= 90) letter = 'A';
        else if (finalGrade >= 75) letter = 'B';
        else if (finalGrade >= 60) letter = 'C';
        else if (finalGrade >= 50) letter = 'D';
        else letter = 'F';

        return letter;
    }

    public static double CalculateGPA(int studentId , UniversityDbContext context)
    {
        var grades = context.Grade.Where(g => g.StudentId == studentId).Select(g => new
            {
                g.GradeVal,
                g.Assignment.Weight,
                g.Assignment.CourseId
            })
            .ToList();

        var courseCount = grades.Select(g => g.CourseId).Distinct().Count();

        var sum = grades.Sum(g =>
            ((g.GradeVal ?? 0) / 100.0) * g.Weight
        );

        var gpa = sum / courseCount;

        return gpa / 25.0;
    }
}