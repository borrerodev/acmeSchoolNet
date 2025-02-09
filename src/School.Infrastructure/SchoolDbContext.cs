namespace School.Infrastructure;

using Microsoft.EntityFrameworkCore;
using School.Domain.Abstractions;
using School.Domain.Entities.Course;
using School.Domain.Entities.Student;

//school> dotnet ef --verbose migrations add InitialSchool -p src/School.Infrastructure -s src/School.Api
public sealed class SchoolDbContext : DbContext, IUnitOfWork
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

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
       var result = await base.SaveChangesAsync(cancellationToken);
       return result;
    }
}
