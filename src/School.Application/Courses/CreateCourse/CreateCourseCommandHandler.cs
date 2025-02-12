using MediatR;
using School.Domain.Abstractions;
using School.Domain.Entities.Course;

namespace School.Application.Courses.CreateCourse;

internal sealed class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, Guid>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IUnitOfWork _unitOfWork;   

    public CreateCourseCommandHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
    {
        _courseRepository = courseRepository;
        _unitOfWork = unitOfWork;
    }  

    public async Task<Guid> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var courseNew = Course.Create(request.Name, request.RegistrationFee, request.StartDate, request.EndDate);        
        _courseRepository.Add(courseNew);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return courseNew.Id;
    }
}
