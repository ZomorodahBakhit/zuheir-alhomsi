using EFAssignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFAssignment.ClassMapping;

public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
{
    void IEntityTypeConfiguration<Assignment>.Configure(EntityTypeBuilder<Assignment> builder)
    {
        builder.HasKey(a => a.AssignmentId);
        builder.Property(a => a.AssignmentTitle).IsRequired().HasMaxLength(100);
        builder.Property(a => a.Weight).IsRequired();
        builder.ToTable(t =>
        {
            t.HasCheckConstraint("CK_Assignment_Weight", "[Weight] >= 0 AND [Weight] <= 100");
        });
        builder.Property(a => a.MaxGrade).IsRequired();
        builder.ToTable(t =>
        {
            t.HasCheckConstraint("CK_Assignment_MaxGrade", "[MaxGrade] >= 0 AND [MaxGrade] <= 100");
        });
        builder.Property(a => a.DueDate).IsRequired();
        builder.HasOne(a => a.Course).WithMany(a => a.Assignments).HasForeignKey(a => a.CourseId);
    }
}