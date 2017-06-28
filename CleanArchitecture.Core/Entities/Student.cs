 

using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Core.Contracts;

namespace CleanArchitecture.Core.Entities
{
    public class Student : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<Course> RegisteredCourses { get; }
        public IList<Course> EnrolledCourses { get; }

        public Student()
        {
            RegisteredCourses = new List<Course>();
            EnrolledCourses = new List<Course>();
        }

        public bool RegisterForCourse(Course course)
        {
            // student has not previously enrolled
            if (EnrolledCourses.Any(ec => ec.Code == course.Code)) return false;

            // registratraion cannot occur with 5 days of course start date
            if (DateTime.UtcNow > course.StartDate.AddDays(-5)) return false;

            RegisteredCourses.Add(course);
            return true;
        }

        public void EnrollInCourse(Course course)
        {
            EnrolledCourses.Add(course);
        }
    }
}
