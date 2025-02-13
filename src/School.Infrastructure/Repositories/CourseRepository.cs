

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
            .Include(x => x.Students)
            .Select(x => new Course
            {
                Id = x.Id,
                Name = x.Name,
                RegistrationFee = x.RegistrationFee,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Students = x.Students.ToList()
    
            })
            .ToListAsync(cancellationToken);
    }
}