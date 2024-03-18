using Microsoft.AspNetCore.Mvc;
using school_management_api.Models;
using school_management_api.Models.DTOs;
using school_management_api.Storage.Context;

namespace school_management_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController(DatabaseContext db) : ControllerBase
{
    private readonly DatabaseContext _db = db;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateStudent([FromBody] StudentCreateDTO studentDTO)
    {
        if (studentDTO == null)
        {
            return BadRequest();
        }

        StudentModel student = new()
        {
            Id = Guid.NewGuid(),
            FirstName = studentDTO.FirstName,
            LastName = studentDTO.LastName,
            DateOfBirth = studentDTO.DateOfBirth,
        };

        await _db.Students.AddAsync(student);
        await _db.SaveChangesAsync();

        return NoContent();
    }
}
