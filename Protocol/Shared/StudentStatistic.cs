
using Protocol.Shared.Enum;

namespace Protocol.Shared;

public struct StudentStatistic
{
    public StudentStatistic(string name, int semester, double avarage, int failCount, Grade bestGrade)
    {
        Name = name;
        Semester = semester;
        Avarage = avarage;
        FailCount = failCount;
        BestGrade = bestGrade;
    }

    /// <summary>
    /// The name of the student
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The semester the student is currently attending
    /// </summary>
    public int Semester { get; set; }

    /// <summary>
    /// The gradeing avarage of the student (overall in all subjects)
    /// </summary>
    public double Avarage { get; set; }

    /// <summary>
    /// The number of failed grades the student has
    /// </summary>
    public int FailCount { get; set; }

    /// <summary>
    /// The best grade the student has ever received
    /// </summary>
    public Grade BestGrade { get; set; }
}
