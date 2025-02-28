
using School.Domain.Entities.Students;

namespace School.Infrastructure.Repositories;

internal sealed class StudentRepository : Repository<Student>, IStudentRepository
{
    public StudentRepository(SchoolDbContext context) : base(context)
    {
    }
}