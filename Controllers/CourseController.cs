using Microsoft.AspNetCore.Mvc;
using school_management_api.Models.DTOs;
using school_management_api.Models;
using school_management_api.Storage.Context;
using Microsoft.EntityFrameworkCore;

namespace school_management_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseController(DatabaseContext db) : ControllerBase
{
    private readonly DatabaseContext _db = db;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<CourseModel>>> GetAllCourses()
    {
        return Ok(await _db.Courses.ToListAsync());
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCourse([FromBody] CourseCreateDTO courseDTO)
    {
        if (courseDTO == null)
        {
            return BadRequest();
        }

        CourseModel course = new()
        {
            Id = Guid.NewGuid(),
            TeacherId = courseDTO.TeacherId,
            Name = courseDTO.Name,
            Description = courseDTO.Description,
            AttendedStudents = 0
        };

        await _db.Courses.AddAsync(course);
        await _db.SaveChangesAsync();

        return NoContent();
    }
}
