using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;

namespace Core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController(StudentRegistryContext context, IConfiguration configuration) : ControllerBase
{
    private readonly StudentRegistryContext _context = context;
    private readonly IConfiguration _configuration = configuration;

    [HttpPost("Entity/{usingJoin}")]
    public async Task PostUsingEntity([FromRoute] bool usingJoin)
    {
        var now = DateTimeOffset.Now;

            if (!usingJoin)
        {
            for (int i = 0; i < 1000000; i++)
            {
                await _context.Students.AddAsync(
                    new Models.StudentRegistry.Student()
                    {
                        Name = $"Student{i}",
                        MobileNumber = $"{i}",
                        Birthday = now,
                        Semester = 1,
                    }
                );
            }
        }
        else
        {
            for (int i = 0; i < 500000; i++)
            {

                var newStudent = new Models.StudentRegistry.Student()
                {
                    Name = $"Student{i}",
                    MobileNumber = $"{i}",
                    Birthday = now,
                    Semester = 1,
                };

                newStudent.Grades ??= [];

                newStudent.Grades.Add(new Models.StudentRegistry.StudentGrade()
                {
                    SubjectId = 1,
                    Grade = Protocol.Shared.Enum.Grade.Five,
                });

                await _context.Students.AddAsync(newStudent);
            }
        }

        await _context.SaveChangesAsync();
    }

    [HttpPut("Entity")]
    public async Task PutUsingEntity()
    {

    }

    [HttpGet("Entity")]
    public async Task GetUsingEntity()
    {

    }

    [HttpPost("SQL/{usingJoin}")]
    public int PostUsingSQL([FromRoute] bool usingJoin)
    {
        var now = DateTimeOffset.Now;
        int totalInserted = 0;

        using (SqliteConnection con = new SqliteConnection(_configuration.GetConnectionString("DbConnectionString")))
        {
            if(!usingJoin)
            {
                string query =
                    @"
                    INSERT INTO Students (name, semester, mobilenumber, birthday) VALUES
                    (@name, @semester, @mobilenumber, @birthday);
                ";

                using (SqliteCommand command = new SqliteCommand(query, con))
                {
                    con.Open();

                    command.Parameters.AddWithValue("@name", "Test");
                    command.Parameters.Add("@semester", SqliteType.Integer);
                    command.Parameters.Add("@mobilenumber", SqliteType.Text);
                    command.Parameters.Add("@birthday", SqliteType.Text);

                    for (int i = 1; i <= 1000000; i++)
                    {
                        command.Parameters["@semester"].Value = i;
                        command.Parameters["@mobilenumber"].Value = $"123456789{i}";
                        command.Parameters["@birthday"].Value = now;

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            totalInserted++;
                        }
                        else
                        {
                            Console.WriteLine($"Error inserting data into Database on iteration {i}!");
                        }
                    }
                }
            }
            else
            {
                string studentQuery =
                @"
                    INSERT INTO Students (name, semester, mobilenumber, birthday) VALUES
                    (@name, @semester, @mobilenumber, @birthday);
";

                string gradesQuery =
                    @"
                        INSERT INTO StudentGrades (StudentId, SubjectId, Grade) VALUES
                        (@studentId, @subjectId, @grade);
";

                using (SqliteCommand studentCommand = new SqliteCommand(studentQuery, con))
                using (SqliteCommand gradesCommand = new SqliteCommand(gradesQuery, con))
                {
                    con.Open();

                    studentCommand.Parameters.AddWithValue("@name", "Test");
                    studentCommand.Parameters.Add("@semester", SqliteType.Integer);
                    studentCommand.Parameters.Add("@mobilenumber", SqliteType.Text);
                    studentCommand.Parameters.Add("@birthday", SqliteType.Text);

                    gradesCommand.Parameters.Add("@studentId", SqliteType.Integer);
                    gradesCommand.Parameters.Add("@subjectId", SqliteType.Integer);
                    gradesCommand.Parameters.Add("@grade", SqliteType.Integer);

                    for (int i = 1; i <= 1000000; i++)
                    {
                        // Insert into Students table
                        studentCommand.Parameters["@semester"].Value = i;
                        studentCommand.Parameters["@mobilenumber"].Value = $"12345{i}";
                        studentCommand.Parameters["@birthday"].Value = now;

                        int studentResult = studentCommand.ExecuteNonQuery();

                        if (studentResult > 0)
                        {
                            totalInserted++;

                            // Get the last inserted StudentId
                            string getLastIdQuery = "SELECT last_insert_rowid();";
                            long lastInsertedId;
                            using (SqliteCommand getLastIdCommand = new SqliteCommand(getLastIdQuery, con))
                            {
                                lastInsertedId = (long)getLastIdCommand.ExecuteScalar();
                            }

                            // Insert into StudentGrades table
                            gradesCommand.Parameters["@studentId"].Value = lastInsertedId;
                            gradesCommand.Parameters["@subjectId"].Value = 1; // Example SubjectId
                            gradesCommand.Parameters["@grade"].Value = 3; // Example Grade (e.g., C)

                            int gradesResult = gradesCommand.ExecuteNonQuery();

                            if (gradesResult <= 0)
                            {
                                Console.WriteLine($"Error inserting grade for StudentId {lastInsertedId} on iteration {i}!");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Error inserting data into Students table on iteration {i}!");
                        }
                    }
                }

            }
        }

        return totalInserted;
    }


    [HttpPut("SQL")]
    public async Task PutUsingSQL()
    {

    }

    [HttpGet("SQL")]
    public async Task GetUsingSQL()
    {

    }

    [HttpPost("SQLInjection/{intrusion}")]
    public async Task GetUsingSQL([FromRoute] string intrusion)
    {

    }
}
