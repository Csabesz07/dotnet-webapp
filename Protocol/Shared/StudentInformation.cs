
using System;

namespace Protocol.Shared;

public struct StudentInformation
{
    public StudentInformation(string name, int semester, DateTimeOffset birthday, string mobileNumber)
    {
        Name = name;
        Semester = semester;
        Birthday = birthday;
        MobileNumber = mobileNumber;
    }

    /// <summary>
    /// The student's name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The semester the student is currently attending
    /// </summary>
    public int Semester {  get; set; }

    /// <summary>
    /// The date of the student's birth
    /// </summary>
    public DateTimeOffset Birthday { get; set; }

    /// <summary>
    /// The mobile number of the student
    /// </summary>
    public string MobileNumber { get; set; }
}
