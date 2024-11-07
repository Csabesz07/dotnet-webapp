using Microsoft.EntityFrameworkCore;

namespace Core.Models;

public class StudentRegistryContext : DbContext
{
    public StudentRegistryContext() { }

    public StudentRegistryContext(DbContextOptions<StudentRegistryContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}
