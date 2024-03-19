using Microsoft.AspNetCore.Mvc;
using school_management_api.Models.DTOs;
using school_management_api.Models;
using school_management_api.Storage.Context;

namespace school_management_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeacherController(DatabaseContext db) : ControllerBase
{
    private readonly DatabaseContext _db = db;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateTeacher([FromBody] TeacherCreateDTO teacherDTO)
    {
        if (teacherDTO == null)
        {
            return BadRequest();
        }

        TeacherModel teacher = new()
        {
            Id = Guid.NewGuid(),
            FirstName = teacherDTO.FirstName,
            LastName = teacherDTO.LastName,
            DateOfBirth = teacherDTO.DateOfBirth,
            IsGuest = teacherDTO.IsGuest
        };

        await _db.Teachers.AddAsync(teacher);
        await _db.SaveChangesAsync();

        return NoContent();
    }
}
