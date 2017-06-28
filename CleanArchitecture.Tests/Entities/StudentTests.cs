

using System;
using CleanArchitecture.Core.Entities;
using Xunit;

namespace CleanArchitecture.Tests.Entities
{
    public class StudentTests
    {
        [Fact]
        public void StudentCannotRegisterForCourseWithin5DaysOfStartDate()
        {
            // arrange
            var student = new Student();
            var course = new Course { Code = "BIOL-1507EL", Name = "Biology II", StartDate = DateTime.UtcNow.AddDays(+3) };

            // act
            var result = student.RegisterForCourse(course);

            // assert
            Assert.False(result);
        }
    }
}
