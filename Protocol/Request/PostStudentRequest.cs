
using System;

namespace Protocol.Request;

public struct PostStudentRequest
{
    /// <summary>
    /// The name of the student
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
