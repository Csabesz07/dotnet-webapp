
using Protocol.Shared;
using System.Collections.Generic;

namespace Protocol.Response;

public struct StudentListResponse
{    
    public StudentListResponse(List<StudentInformation> students)
    {
        Students = students;
    }

    /// <summary>
    /// The list of students with their information
    /// </summary>
    public List<StudentInformation> Students { get; set; }
}
