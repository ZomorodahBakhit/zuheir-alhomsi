using EFAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace EFAssignment;

public class UniversityDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Grade> Grade { get; set; }
    public DbSet<Syllabus> Syllabus { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UniversityDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=localhost;Database=UniversityDb2;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}