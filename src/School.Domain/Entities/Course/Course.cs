namespace School.Domain.Entities.Course;

using School.Domain.Abstractions;
using School.Domain.Entities.Course.Events;
using School.Domain.Entities.Student;

public sealed class Course : Entity
{
    public string? Name { get; set; }
    public decimal? RegistrationFee { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ICollection<Student> Students { get; set; } = new List<Student>();

    private Course(
        Guid id, 
        string name, 
        decimal registrationFee, 
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
        decimal registrationFee, 
        DateTime startDate, 
        DateTime endDate)
    {
        var course = new Course(new Guid(), name, registrationFee, startDate, endDate);
        course.RaiseDomainEvent(new CourseCreatedDomainEvent(course.Id));
        return course;
    }
}
