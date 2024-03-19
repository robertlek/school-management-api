namespace school_management_api.Models.DTOs;

public class CourseCreateDTO
{
    public Guid TeacherId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}
