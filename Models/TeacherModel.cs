﻿using System.ComponentModel.DataAnnotations;

namespace school_management_api.Models;

public class TeacherModel
{
    [Key]
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public bool IsGuest { get; set; }
}
