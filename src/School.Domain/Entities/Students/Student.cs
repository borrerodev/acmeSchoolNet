namespace School.Domain.Entities.Students;

using School.Domain.Abstractions;
using School.Domain.Entities.Courses;
using School.Domain.Entities.Enrollments;
using School.Domain.Entities.Students.Events;

public class Student : Entity
{
    public string? Name { get; private set; }
    public int Age { get; private set; }
     public Guid? CourseId { get; set; } // Foreign key property
    // public Course? Course { get; set; } 
    public ICollection<Course> Courses { get; set; } = new List<Course>();
    
    public Student()
    {
        
    }
    private Student(Guid id, string name, int age) : base(id)
    {
        Name = name;    
        Age = age;
    }

    public static Student Create(string name, int age)
    {
        var student = new Student(new Guid(), name, age);
        student.RaiseDomainEvent(new StudentCreatedDomainEvent(student.Id));
        return student;
    }

    public static void AssignCourse(Student student, Course course)
    {            
        student.CourseId = course.Id;
        student.Courses.Add(course);
    }

}
