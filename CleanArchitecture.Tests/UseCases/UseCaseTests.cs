 
using CleanArchitecture.Core.Contracts;
using CleanArchitecture.Core.Dto;
using CleanArchitecture.Core.UseCases;
using Moq;
using Xunit;

namespace CleanArchitecture.Tests.UseCases
{
    public class UseCaseTests
    {
        [Fact]
        public void CannotRegisterForCoursesWhenNotLoggedIn()
        {
            // arrange
            var mockAuthService = new Mock<IAuthService>();
            mockAuthService.Setup(a => a.IsAuthenticated()).Returns(() => false);
            var useCase = new RequestCourseRegistrationInteractor(mockAuthService.Object);

            // act
            var response = useCase.Handle(new CourseRegistrationRequestMessage());

            // assert
            Assert.False(response.Success);
            Assert.Equal(response.Message, "Operation failed, not authenticated.");
        }
    }
}
