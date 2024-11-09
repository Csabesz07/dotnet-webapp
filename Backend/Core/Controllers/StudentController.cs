using BusinessLogic.Validators;
using Core.Converters;
using Core.Models;
using Core.Models.StudentRegistry;
using Microsoft.AspNetCore.Authorization;
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

    [Authorize]
    [HttpPost]
    [ProducesResponseType(typeof(CreatedResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<int>> PostStudent([FromBody] PostStudentRequest student)
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
            var newStudent = student.ToStudent();
            await _context.Students.AddAsync(newStudent);
            await _context.SaveChangesAsync();

            return Ok(newStudent.Id);
        }
        catch (Exception ex) 
        { 
            return Problem(ex.Message);
        }
    }

    [Authorize]
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
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetStudentStatisticsList()
    {
        try
        {
            var studentList =
                await _context.Students
                .Include(s => s.Grades)
                .Where(s => s.Grades != null && s.Grades.Count > 0)
                .Select(s => s.ToStudentStatistic())
                .ToListAsync();

            studentList.Sort();

            return Ok(studentList.StudentStatisticsListResponse());
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet("Subject")]
    public async Task<ActionResult<List<Subject>>> GetSubjects()
    {
        return await _context.Subjects.ToListAsync();
    }
}
