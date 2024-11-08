
using Protocol.Request;
using System;
using System.Linq;

namespace BusinessLogic.Validators;

public class StudentValidator
{
    public StudentValidator ValidateNewStudentName(PostStudentRequest student)
    {
        if (string.IsNullOrWhiteSpace(student.Name))
            throw new Exception("Name should be at least 1 charater long");

        if(student.Name.Any(char.IsDigit))
            throw new Exception("Name shouldn't contain any numeric characters");

        return this;
    }

    public StudentValidator ValidateNewStudentSemester(PostStudentRequest student)
    {
        if (!student.Semester.ToString().All(char.IsDigit))
            throw new Exception("The semester should be of type integer");

        return this;
    }

    public StudentValidator ValidateNewStudentMobileNumber(PostStudentRequest student)
    {
        if (!student.MobileNumber.All(char.IsDigit))
            throw new Exception("The mobile number should only contain numeric characters");

        return this;
    }
}
