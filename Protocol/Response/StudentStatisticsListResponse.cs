
using Protocol.Shared;
using System.Collections.Generic;

namespace Protocol.Response;

public struct StudentStatisticsListResponse
{    
    public StudentStatisticsListResponse(List<StudentStatistic> students) 
    { 
        Students = students;
    }

    /// <summary>
    /// The list of students with their grade statistics
    /// </summary>
    public List<StudentStatistic> Students { get; set; } = null;
}
