namespace School.Domain.Entities.Courses;

public interface ICourseRepository
{
    void Add(Course course);
    Task<List<Course>> GetByRange(DateTime startDate, DateTime endDate, CancellationToken cancellationToken);
    void EnrollStudent(Guid courseId, Guid studentId, CancellationToken cancellationToken);
    Task<List<Course>> GetAll(CancellationToken cancellationToken);

}