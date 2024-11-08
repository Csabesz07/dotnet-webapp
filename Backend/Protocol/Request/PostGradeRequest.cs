
using Protocol.Shared.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Protocol.Request;

public struct PostGradeRequest
{
    /// <summary>
    /// The student whom receives the grade
    /// </summary>
    //[JsonRequired]
    //[Required]
    public int StudentId {  get; set; }

    /// <summary>
    /// The subject which the grade should be assigned to
    /// </summary>
    //[JsonRequired]
    //[Required]
    public int SubjectId { get; set; }

    /// <summary>
    /// The grade
    /// </summary>
    //[JsonRequired]
    //[Required]
    public Grade Grade { get; set; }
}
