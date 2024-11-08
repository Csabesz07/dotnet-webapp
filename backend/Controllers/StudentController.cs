using BusinessLogic.Validators;
using Core.Models;
using Core.Models.StudentRegistry;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Protocol.Request;
using Protocol.Response;

namespace Core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController(StudentRegistryContext context, IConfiguration configuration) : ControllerBase
{
    private readonly StudentRegistryContext _context = context;
    private readonly IConfiguration _configuration = configuration;
    private readonly StudentValidator _studentValidator = new();
    private readonly GradeValidator _gradeValidator = new();

    [HttpPost]
    [ProducesResponseType(typeof(CreatedResult), StatusCodes.Status201Created)]
    public async Task<ActionResult> PostStudent([FromBody] PostStudentRequest student)
    {
        throw new NotImplementedException();
    }

    [HttpPost("Grade")]
    [ProducesResponseType(typeof(CreatedResult), StatusCodes.Status201Created)]
    public async Task<ActionResult> PostStudentGrade([FromBody] PostGradeRequest grade)
    {
        throw new NotSupportedException();
    }

    [HttpGet("List")]
    [ProducesResponseType(typeof(StudentListResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult> GetStudentList()
    {
        throw new NotImplementedException();
    }

    [HttpGet("List/Statistics")]
    [ProducesResponseType(typeof(StudentStatisticsListResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult> GetStudentStatisticsList()
    {
        throw new NotImplementedException();
    }

    [HttpGet("Subject")]   
    public async Task<ActionResult<List<Subject>>> GetSubjects()
    {
        return await _context.Subjects.ToListAsync();
    }
}
