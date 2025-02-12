using MediatR;

namespace School.Application.Enrollments.NewEnroll;

public sealed record NewEnrollCommand(
    Guid StudentId,
    Guid CourseId
) : IRequest<Guid>;
