using MediatR;
using School.Domain.Abstractions;
using School.Domain.Entities.Students;

namespace School.Application.Students.CreateStudent;

public sealed class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Guid>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IUnitOfWork _unitOfWork;   

    public CreateStudentCommandHandler(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
    {
        _studentRepository = studentRepository;
        _unitOfWork = unitOfWork;
    }  

    public async Task<Guid> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var studentNew = Student.Create(request.Name, request.Age);        
        _studentRepository.Add(studentNew);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return studentNew.Id;
    }
}
