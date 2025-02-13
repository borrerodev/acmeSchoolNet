namespace School.Domain.Entities.Courses;

using School.Domain.Abstractions;
using School.Domain.Entities.Courses.Events;
using School.Domain.Entities.Enrollments;
using School.Domain.Entities.Students;

public sealed class Course : Entity
{
    public string? Name { get; set; }
    
    public int RegistrationFee { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ICollection<Student> Students { get; set; }

    private Course(
        Guid id, 
        string name, 
        int registrationFee, 
        DateTime startDate, 
        DateTime endDate
    ) : base(id)
    {
        Name = name;
        RegistrationFee = registrationFee;
        StartDate = startDate;
        EndDate = endDate;
    }
    public Course()
    {
        
    }
    public static Course Create(
        string name, 
        int registrationFee, 
        DateTime startDate, 
        DateTime endDate)
    {
        var course = new Course(new Guid(), name, registrationFee, startDate, endDate);
        course.RaiseDomainEvent(new CourseCreatedDomainEvent(course.Id));
        return course;
    }
}
