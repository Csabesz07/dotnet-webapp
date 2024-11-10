
using Protocol.Shared.Enum;

namespace Protocol.Request;

public struct PostGradeRequest
{
    /// <summary>
    /// The student whom receives the grade
    /// </summary>    
    public int StudentId {  get; set; }

    /// <summary>
    /// The subject which the grade should be assigned to
    /// </summary>
    public int SubjectId { get; set; }

    /// <summary>
    /// The grade
    /// </summary>
    public Grade Grade { get; set; }
}
