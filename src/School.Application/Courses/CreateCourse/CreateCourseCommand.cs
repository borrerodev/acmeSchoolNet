using MediatR;

namespace School.Application.Courses.CreateCourse;

public sealed record CreateCourseCommand(
    string Name,
    int RegistrationFee,
    DateTime StartDate,
    DateTime EndDate
) : IRequest<Guid>;
