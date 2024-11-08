using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Protocol.Shared.Enum;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.Models.StudentRegistry;

public class StudentGrade
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int SubjectId { get; set; }
    public Grade Grade {  get; set; }

    [JsonIgnore]
    public virtual Student Student { get; set; } = null!;

    [JsonIgnore]
    public virtual Subject Subject { get; set; } = null!;

    public sealed class Configuration : IEntityTypeConfiguration<StudentGrade>
    {
        public void Configure(EntityTypeBuilder<StudentGrade> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();

            builder
                .Property(x => x.StudentId)
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property(x => x.SubjectId)
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property(x => x.Grade)
                .HasConversion<EnumToNumberConverter<Grade, int>>()
                .HasColumnType("int")
                .IsRequired();

            builder
                .HasOne(x => x.Student)
                .WithMany(x => x.Grades)
                .HasForeignKey(x => x.StudentId);

            builder
                .HasOne(x => x.Subject)
                .WithMany(x => x.Grades)
                .HasForeignKey(x => x.SubjectId);
        }
    }
}
