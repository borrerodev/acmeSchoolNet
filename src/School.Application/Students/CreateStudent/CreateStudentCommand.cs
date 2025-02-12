using MediatR;

namespace School.Application.Students.CreateStudent;

public sealed record CreateStudentCommand(
    string Name,
    int Age   
) : IRequest<Guid>;
