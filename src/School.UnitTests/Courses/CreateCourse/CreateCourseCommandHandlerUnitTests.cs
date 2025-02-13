using Moq;
using School.Application.Courses.CreateCourse;
using School.Domain.Abstractions;
using School.Domain.Entities.Courses;

namespace School.UnitTests.Courses.CreateCourse;

public class CreateCourseCommandHandlerUnitTests
{
    private readonly Mock<ICourseRepository> _courseRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly CreateCourseCommandHandler _handler;

    public CreateCourseCommandHandlerUnitTests()
    {
        _courseRepositoryMock = new Mock<ICourseRepository>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _handler = new CreateCourseCommandHandler(_courseRepositoryMock.Object, _unitOfWorkMock.Object);
    }

    [Fact]
    public async Task HandleCreateCourseCommand_Create_Ok()
    {

            // Arrange
        var command = new CreateCourseCommand("Test Course", 100, DateTime.UtcNow, DateTime.UtcNow.AddMonths(1));
        var courseId = Guid.NewGuid();

        _courseRepositoryMock.Setup(repo => repo.Add(It.IsAny<Course>())).Callback<Course>(course => course.Id = courseId);
        _unitOfWorkMock.Setup(uow => uow.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(0));

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal(courseId, result);
        _courseRepositoryMock.Verify(repo => repo.Add(It.IsAny<Course>()), Times.Once);
        _unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
    
}
