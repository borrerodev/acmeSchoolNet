using MediatR;
using School.Domain.Abstractions;
using School.Domain.Entities.Enrollments;

namespace School.Application.Enrollments.NewEnroll
{
    public sealed class NewEnrollCommandHandler : IRequestHandler<NewEnrollCommand, Guid>
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NewEnrollCommandHandler(IEnrollmentRepository enrollmentRepository, IUnitOfWork unitOfWork)
        {
            _enrollmentRepository = enrollmentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(NewEnrollCommand request, CancellationToken cancellationToken)
        {
            var enrollmentNew = Enrollment.Create(request.StudentId, request.CourseId);
            _enrollmentRepository.Add(enrollmentNew);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return enrollmentNew.Id;
        }
    }
}
