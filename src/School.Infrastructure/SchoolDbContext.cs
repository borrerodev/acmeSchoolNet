namespace School.Infrastructure;

using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Course;
using School.Domain.Entities.Student;

public sealed class SchoolDbContext : DbContext
{

    public SchoolDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    //public DbSet<Enrollment> Enrollments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SchoolDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
        // modelBuilder.Entity<Student>().ToTable("Student");
        // modelBuilder.Entity<Course>().ToTable("Course");
        //modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
    }
}
