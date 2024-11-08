using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Core.Models.StudentRegistry;

public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<StudentGrade>? Grades { get; set; }

    public sealed class Configuration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();

            builder
                .Property(x => x.Name)
                .HasColumnType("nvarchar(128)")
                .HasMaxLength(128)
                .IsRequired();

            builder
                .HasMany(x => x.Grades)
                .WithOne(x => x.Subject)
                .HasForeignKey(x => x.SubjectId);
        }
    }
}
