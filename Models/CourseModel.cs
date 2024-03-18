using System.ComponentModel.DataAnnotations;

namespace school_management_api.Models;

public class CourseModel
{
    [Key]
    public Guid Id { get; set; }
    public Guid TeacherId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int AttendedStudents { get; set; }
}
