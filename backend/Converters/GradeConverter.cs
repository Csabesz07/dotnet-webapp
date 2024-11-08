using Core.Models.StudentRegistry;
using Protocol.Request;

namespace Core.Converters;

public static class GradeConverter
{
    public static StudentGrade ToStudentGrade(this PostGradeRequest request) =>
        new()
        {
            StudentId = request.StudentId,
            SubjectId = request.SubjectId,
            Grade = request.Grade,
        };
}
