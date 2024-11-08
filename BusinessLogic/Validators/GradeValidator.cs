
using Protocol.Request;
using Protocol.Shared.Enum;
using System;

namespace BusinessLogic.Validators;

public class GradeValidator
{
    public GradeValidator ValidateGrade(PostGradeRequest grade)
    {
        if (!Enum.IsDefined(typeof(Grade), grade.Grade))
            throw new Exception("Invalid grade! Grade should be between 1 and 5");

        return this;
    }
}
