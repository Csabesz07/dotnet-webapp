
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Protocol.Request;

public struct PostStudentRequest
{
    /// <summary>
    /// The name of the student
    /// </summary>
    //[JsonRequired]
    //[Required]
    public string Name { get; set; }

    /// <summary>
    /// The semester the student is currently attending
    /// </summary>
    //[JsonRequired]
    //[Required]
    public int Semester {  get; set; }

    /// <summary>
    /// The date of the student's birth
    /// </summary>
    //[JsonRequired]
    //[Required]
    public DateTimeOffset Birthday { get; set; }

    /// <summary>
    /// The mobile number of the student
    /// </summary>
    //[JsonRequired]
    //[Required]
    public string MobileNumber { get; set; }
}
