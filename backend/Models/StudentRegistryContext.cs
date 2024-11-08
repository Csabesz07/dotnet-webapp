using Core.Models.StudentRegistry;
using Microsoft.EntityFrameworkCore;

namespace Core.Models;

public class StudentRegistryContext : DbContext
{
    public StudentRegistryContext() 
    {
        Database.SetCommandTimeout(240);
    }

    public StudentRegistryContext(DbContextOptions<StudentRegistryContext> options)
        : base(options)
    {
        Database.SetCommandTimeout(240);
    }

    public virtual DbSet<Student> Students { get; set; } = null!;
    public virtual DbSet<StudentGrade> StudentGrades { get; set; } = null!;
    public virtual DbSet<Subject> Subjects { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Student.Configuration());
        modelBuilder.ApplyConfiguration(new StudentGrade.Configuration());
        modelBuilder.ApplyConfiguration(new Subject.Configuration());
    }
}
