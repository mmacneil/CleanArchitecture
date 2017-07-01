 
using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Core.Contracts;
using CleanArchitecture.Core.Dto;
using CleanArchitecture.Core.Entities;
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
            var useCase = new RequestCourseRegistrationInteractor(mockAuthService.Object,null,null);

            // act
            var response = useCase.Handle(new CourseRegistrationRequestMessage(int.MinValue,null));

            // assert
            Assert.False(response.Success);
            Assert.Equal(response.Message, "Operation failed, not authenticated.");
        }

        [Fact]
        public void CannotRegisterForCourseAlreadyEnrolledIn()
        {
            // arrange
            var mockAuthService = new Mock<IAuthService>();
            mockAuthService.Setup(a => a.IsAuthenticated()).Returns(() => true);

            var mockCourseRepository = new Mock<ICourseRepository>();
            mockCourseRepository.Setup(cr => cr.GetByCode(It.IsAny<string>())).Returns(() => new Course
            {
                Code = "BL0150"
            });

            var mockStudentRepository = new Mock<IStudentRepository>();
            mockStudentRepository.Setup(sr => sr.GetById(It.IsAny<int>())).Returns(() => new Student
            {
                EnrolledCourses = new List<Course>
                {
                    new Course {Code = "BL0150"}
                }
            });

            var useCase = new RequestCourseRegistrationInteractor(mockAuthService.Object,mockStudentRepository.Object,mockCourseRepository.Object);

            // act
            var response = useCase.Handle(new CourseRegistrationRequestMessage(int.MinValue,new List<string> { "BL0150" }));

            // assert
            Assert.False(response.Success);
            Assert.True(response.Errors.Any(e => e == "unable to register for BL0150"));
        }

        [Fact]
        public void CannotRegisterForCourseWithin5DaysOfStartDate()
        {
            // arrange
            var mockAuthService = new Mock<IAuthService>();
            mockAuthService.Setup(a => a.IsAuthenticated()).Returns(() => true);

            var mockCourseRepository = new Mock<ICourseRepository>();
            mockCourseRepository.Setup(cr => cr.GetByCode(It.IsAny<string>())).Returns(() => new Course
            {
                Code = "BL0150",
                StartDate = DateTime.UtcNow.AddDays(3)
            });

            var mockStudentRepository = new Mock<IStudentRepository>();
            mockStudentRepository.Setup(sr => sr.GetById(It.IsAny<int>())).Returns(() => new Student());

            var useCase = new RequestCourseRegistrationInteractor(mockAuthService.Object, mockStudentRepository.Object, mockCourseRepository.Object);

            // act
            var response = useCase.Handle(new CourseRegistrationRequestMessage(int.MinValue, new List<string> { "BL0150" }));

            // assert
            Assert.False(response.Success);
            Assert.True(response.Errors.Any(e => e == "unable to register for BL0150"));
        }
    }
}
