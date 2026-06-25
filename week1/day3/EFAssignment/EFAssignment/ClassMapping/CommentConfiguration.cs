using EFAssignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFAssignment.ClassMapping;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    void IEntityTypeConfiguration<Comment>.Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(c => c.CommentId);
        builder.Property(c => c.CreatedDate).IsRequired();
        builder.Property(c => c.CommentContent).HasMaxLength(1000);

        builder.HasOne(c => c.Assignments).WithMany(a => a.Comments).HasForeignKey(c => c.AssignmentId);
        builder.HasOne(c => c.User).WithMany(u => u.Comments).HasForeignKey(c => c.CreatedByUserId);
    }
}