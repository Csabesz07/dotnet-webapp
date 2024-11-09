
using Core.Models.StudentRegistry;
using Protocol.Request;
using Protocol.Response;
using Protocol.Shared;
using Protocol.Shared.Enum;

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
            Id = student.Id,
            Name = student.Name,
            Semester = student.Semester,
            Birthday = student.Birthday,
            MobileNumber = student.MobileNumber,
        };

    public static StudentListResponse ToStudentListResponse(this List<StudentInformation> students) =>
        new(students);

    public static StudentStatistic ToStudentStatistic(this Student student) =>
        new()
        {
            Id = student.Id,
            Name = student.Name,
            Avarage = student.Grades!.Average(s => (int)s.Grade),
            FailCount = student.Grades!.Where(s => s.Grade == Grade.One).Count(),
            BestGrade = student.Grades!.Select(s => s.Grade).Max(),
        };

    public static StudentStatisticsListResponse StudentStatisticsListResponse(this List<StudentStatistic> statistics) =>
        new(statistics);
}
