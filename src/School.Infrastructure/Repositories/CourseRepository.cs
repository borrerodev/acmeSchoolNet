

using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Courses;

namespace School.Infrastructure.Repositories;

internal sealed class CourseRepository : Repository<Course>, ICourseRepository
{
    public CourseRepository(SchoolDbContext context) : base(context){}

    public async Task<List<Course>> GetByRange(DateTime startDate, DateTime endDate, CancellationToken cancellationToken)
    {
        return await dbContext.Set<Course>()
            .Where(x => x.StartDate >= startDate && x.EndDate <= endDate)
            .ToListAsync(cancellationToken);
    }
    public void EnrollStudent(Guid courseId, Guid studentId, CancellationToken cancellationToken)
    {
       // var course = dbContext.Set<Course>().Include(x => x.s).FirstOrDefault(x => x.Id == courseId);
    }

    public async Task<List<Course>> GetAll(CancellationToken cancellationToken)
    {
        return await dbContext.Set<Course>().ToListAsync(cancellationToken);
    }
}