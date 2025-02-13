
using Moq;
using Xunit;
using School.Application.Students.CreateStudent;
using School.Domain.Abstractions;
using School.Domain.Entities.Students;

namespace School.Application.Tests.Students.CreateStudent
{
    public class CreateStudentCommandHandlerTest
    {
        private readonly Mock<IStudentRepository> _studentRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly CreateStudentCommandHandler _handler;

        public CreateStudentCommandHandlerTest()
        {
            _studentRepositoryMock = new Mock<IStudentRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _handler = new CreateStudentCommandHandler(_studentRepositoryMock.Object, _unitOfWorkMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreateStudentAndReturnId()
        {
            // Arrange
            var command = new CreateStudentCommand("Jorge Test", 21);
            var studentId = Guid.NewGuid();
            
            _studentRepositoryMock.Setup(repo => repo.Add(It.IsAny<Student>())).Callback<Student>(student => student.Id = studentId);
            _unitOfWorkMock.Setup(uow => uow.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(0));

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(studentId, result);
            _studentRepositoryMock.Verify(repo => repo.Add(It.IsAny<Student>()), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}