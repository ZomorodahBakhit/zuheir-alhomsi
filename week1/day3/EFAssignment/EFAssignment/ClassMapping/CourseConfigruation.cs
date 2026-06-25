using EFAssignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFAssignment.ClassMapping;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    void IEntityTypeConfiguration<Course>.Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(c => c.CourseId);
        builder.Property(c => c.CourseName).IsRequired(true).HasMaxLength(100);
        builder.Property(c => c.StartDate).IsRequired(true);
        builder.Property(c => c.EndDate).IsRequired(true);

        builder.HasOne(c => c.Teacher).WithMany(u => u.Courses).HasForeignKey(c => c.TeacherId);
        builder.HasOne(c => c.Syllabus).WithOne(s => s.Course).HasForeignKey<Syllabus>(s => s.CourseId);
    }
}