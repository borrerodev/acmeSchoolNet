namespace School.Domain.Entities.Courses;

public interface ICourseRepository
{
    void Add(Course course);
    Task<List<Course>> GetByRange(DateTime startDate, DateTime endDate, CancellationToken cancellationToken);
}