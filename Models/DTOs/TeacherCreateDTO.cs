namespace school_management_api.Models.DTOs;

public class TeacherCreateDTO
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public bool IsGuest { get; set; }
}
