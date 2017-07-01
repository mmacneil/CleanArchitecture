 

using System.Collections.Generic;
using CleanArchitecture.Core.Contracts;
using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.ConsoleApp.Gateways
{
    public class StudentRepository : IStudentRepository
    {
        private Student _student = new Student();
        public Student GetById(int id)
        {
            return _student;

            /*return new Student
            {
                Id = id,
                EnrolledCourses = new List<Course>
                {
                    new Course {Code = "BIO150"}
                },
                FirstName = "Mark",
                LastName = "Macneil"
            };*/
        }

        public void Save(Student student)
        {
            _student = student;
        }
    }
}
