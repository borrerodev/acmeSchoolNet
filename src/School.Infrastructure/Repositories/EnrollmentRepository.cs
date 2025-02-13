using School.Domain.Entities.Enrollments;

namespace School.Infrastructure.Repositories;

internal sealed class EnrollmentRepository : Repository<Enrollment>, IEnrollmentRepository
{
    public EnrollmentRepository(SchoolDbContext context) : base(context)
    {

    }
}
