
using Protocol.Shared.Enum;
using System;

namespace Protocol.Shared;

public struct StudentStatistic : IComparable<StudentStatistic>
{
    public StudentStatistic(int id, string name, double? avarage, int? failCount, Grade? bestGrade)
    {
        Id = id;
        Name = name;
        Avarage = avarage;
        FailCount = failCount;
        BestGrade = bestGrade;
    }

    /// <summary>
    /// The database Id of the student
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The name of the student
    /// </summary>
    public string Name { get; set; }    

    /// <summary>
    /// The gradeing avarage of the student (overall in all subjects)
    /// </summary>
    public double? Avarage { get; set; }

    /// <summary>
    /// The number of failed grades the student has
    /// </summary>
    public int? FailCount { get; set; }

    /// <summary>
    /// The best grade the student has ever received
    /// </summary>
    public Grade? BestGrade { get; set; }

    /// <summary>
    /// Sorting function by grade avarage
    /// </summary>
    /// <param name="other">The student who the name should be compared to</param>
    /// <returns>An signed int which represents the position relative to this element</returns>
    public int CompareTo(StudentStatistic other)
    {
        if (!Avarage.HasValue && !other.Avarage.HasValue) return 0;
        if (!Avarage.HasValue) return 1;
        if (!other.Avarage.HasValue) return -1;

        return other.Avarage.Value.CompareTo(Avarage.Value);
    }
}
