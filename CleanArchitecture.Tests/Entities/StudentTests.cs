

using System;
using System.Collections.Generic;
using CleanArchitecture.Core.Entities;
using Xunit;

namespace CleanArchitecture.Tests.Entities
{
    public class StudentTests
    {
        [Fact]
        public void CannotRegisterForCourseWithin5DaysOfStartDate()
        {
            // arrange
            var student = new Student();
            var course = new Course { Code = "BIOL-1507EL", Name = "Biology II", StartDate = DateTime.UtcNow.AddDays(+3) };

            // act
            var result = student.RegisterForCourse(course);

            // assert
            Assert.False(result);
        }

        [Fact]
        public void CannotRegisterForCourseAlreadyEnrolledIn()
        {
            // arrange
            var student = new Student
            {
                EnrolledCourses = new List<Course>
                {
                   new Course { Code = "BIOL-1507EL", Name = "Biology II" },
                   new Course { Code = "MATH-4067EL", Name = "Mathematical Theory of Dynamical Systems, Chaos and Fractals" }
                }
            };

            // act
            var result = student.RegisterForCourse(new Course { Code = "BIOL-1507EL" });

            // assert
            Assert.False(result);
        }
    }
}
