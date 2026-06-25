using EFAssignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFAssignment.ClassMapping;

public class GradeConfiguration : IEntityTypeConfiguration<Grade>
{
    void IEntityTypeConfiguration<Grade>.Configure(EntityTypeBuilder<Grade> builder)
    {
        builder.HasKey(g => g.GradeId);
        builder.Property(g => g.AssignmentId).IsRequired();
        builder.Property(g => g.StudentId).IsRequired();

        builder.HasOne(g => g.Assignment).WithMany(a => a.Grades).HasForeignKey(g => g.AssignmentId);
        builder.HasOne(g => g.Student).WithMany(u => u.Grades).HasForeignKey(g => g.StudentId);
    }
}