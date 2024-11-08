
using Core.Models.StudentRegistry;
using Protocol.Request;

namespace Core.Converters;

public static class StudentConverter
{
    public static Student ToStudent(this PostStudentRequest request) =>
        new()
        {
            Name = request.Name,
            Semester = request.Semester,
            Birthday = request.Birthday,
            MobileNumber = request.MobileNumber,
        };
}
