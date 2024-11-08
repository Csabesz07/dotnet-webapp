using BusinessLogic.Validators;
using Core.Converters;
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
    [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> PostStudent([FromBody] PostStudentRequest student)
    {
        try
        {
            _studentValidator
                .ValidateNewStudentName(student)
                .ValidateNewStudentSemester(student)
                .ValidateNewStudentMobileNumber(student);
        }
        catch (Exception ex)
        { 
            return BadRequest(ex.Message);
        }

        try
        {
            await _context.Students.AddAsync(student.ToStudent());
            await _context.SaveChangesAsync();

            return Created();
        }
        catch (Exception ex) 
        { 
            return Problem(ex.Message);
        }
    }

    [HttpPost("Grade")]
    [ProducesResponseType(typeof(CreatedResult), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> PostStudentGrade([FromBody] PostGradeRequest grade)
    {
        try
        {
            _gradeValidator.ValidateGrade(grade);
        }
        catch (Exception ex) 
        { 
            return BadRequest(ex.Message);
        }

        try
        {
            await _context.StudentGrades.AddAsync(grade.ToStudentGrade());
            await _context.SaveChangesAsync();

            return Created();
        } catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet("List")]
    [ProducesResponseType(typeof(StudentListResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetStudentList()
    {
        try
        {
            var studentList = 
                await _context.Students
                .Select(s => s.ToStudentInformation())
                .ToListAsync();

            studentList.Sort();

            return Ok(studentList.ToStudentListResponse());
        }
        catch (Exception ex) 
        {
            return Problem(ex.Message);
        }
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
