using EFAssignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFAssignment.ClassMapping;

public class SyllabusConfiguration : IEntityTypeConfiguration<Syllabus>
{
    void IEntityTypeConfiguration<Syllabus>.Configure(EntityTypeBuilder<Syllabus> builder)
    {
        builder.HasKey(s => s.SyllabusId);

        builder.Property(s => s.Description).HasMaxLength(2000);
    }
}