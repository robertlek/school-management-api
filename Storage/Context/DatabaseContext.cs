using Microsoft.EntityFrameworkCore;
using school_management_api.Models;

namespace school_management_api.Storage.Context;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    public DbSet<StudentModel> Students { get; set; }
    public DbSet<TeacherModel> Teachers { get; set; }
    public DbSet<CourseModel> Courses { get; set; }
    public DbSet<AttendedCoursesModel> AttendedCourses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AttendedCoursesModel>().HasNoKey();
    }
}
