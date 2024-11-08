using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Core.Models.StudentRegistry;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Semester {  get; set; }
    public string MobileNumber { get; set; } = null!;
    public DateTimeOffset Birthday { get; set; }

    [JsonIgnore]
    public virtual ICollection<StudentGrade>? Grades { get; set; }

    public sealed class Configuration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => new { x.Id });
            builder.HasIndex(x => x.Id).IsUnique();
            builder.HasIndex(x => x.Semester);

            builder
                .Property(x => x.Name)
                .HasColumnType("nvarchar(128)")
                .HasMaxLength(128)
                .IsRequired();

            builder
                .Property(x => x.Semester)
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property(x => x.MobileNumber)
                .HasColumnType("nvarchar(16)")
                .HasMaxLength(16)
                .IsRequired();

            builder
                .Property(x => x.Birthday)
                .HasColumnType("datetimeoffset(7)")
                .IsRequired();

            builder
                .HasMany(x => x.Grades)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.StudentId);
        }
    }
}
