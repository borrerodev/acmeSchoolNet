namespace School.Domain.Entities.Course;

public interface ICourseRepository
{
    void Add(Course course);
    Task<List<Course>> GetByRange(DateTime startDate, DateTime endDate, CancellationToken cancellationToken);
    void EnrollStudent(Guid courseId, Guid studentId, CancellationToken cancellationToken);
}