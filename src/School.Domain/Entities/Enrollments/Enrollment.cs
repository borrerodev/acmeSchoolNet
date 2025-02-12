using School.Domain.Abstractions;
using School.Domain.Entities.Courses;
using School.Domain.Entities.Students;

namespace School.Domain.Entities.Enrollments;

public class Enrollment : Entity
{
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public DateTime EnrollmentDate { get; set; }

    public Course? Course { get; set; }
    public Student? Student { get; set; }

    public Enrollment()
    {
    }

    private Enrollment(Guid id, Guid studentId, Guid courseId): base(id)
    {
        StudentId = studentId;
        CourseId = courseId;
        EnrollmentDate = DateTime.Now;
    }

    public static Enrollment Create(Guid studentId, Guid courseId)
    {
        var enrollment = new Enrollment(new Guid(), studentId, courseId);
        return enrollment;
    }   
   
}
