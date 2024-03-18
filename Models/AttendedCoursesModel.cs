namespace school_management_api.Models;

public class AttendedCoursesModel
{
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public int Grade { get; set; }
    public DateTime AttendedAt { get; set; }
    public bool IsActive { get; set; }
}
