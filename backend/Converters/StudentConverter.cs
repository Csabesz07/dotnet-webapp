
using Core.Models.StudentRegistry;
using Protocol.Request;
using Protocol.Response;
using Protocol.Shared;

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

    public static StudentInformation ToStudentInformation(this Student student) =>
        new()
        {
            Name = student.Name,
            Semester = student.Semester,
            Birthday = student.Birthday,
            MobileNumber = student.MobileNumber,
        };

    public static StudentListResponse ToStudentListResponse(this List<StudentInformation> students) =>
        new(students);
}
