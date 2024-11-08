
using Protocol.Shared.Enum;
using System;

namespace BusinessLogic.Validators;

public class GradeValidator
{
    public GradeValidator ValidateGrade(Grade grade)
    {
        if (!Enum.IsDefined(typeof(Grade), grade))
            throw new Exception("Invalid grade! Grade should be between 1 and 5");

        return this;
    }
}
