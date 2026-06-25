using EFAssignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFAssignment.ClassMapping;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    void IEntityTypeConfiguration<User>.Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.UserId);
        builder.Property(u => u.UserName).IsRequired(true).HasMaxLength(64);
        builder.Property(u => u.FirstName).IsRequired(true).HasMaxLength(64);
        builder.Property(u => u.LastName).IsRequired(true).HasMaxLength(64);
        builder.Property(u => u.PhoneNumber).IsRequired(true).HasMaxLength(16);
        builder.Property(u => u.EmailAddress).IsRequired().HasMaxLength(128);
        builder.HasIndex(u => u.EmailAddress).IsUnique();
        builder.Property(u => u.Role).IsRequired(true).HasMaxLength(32);

        
    }
}