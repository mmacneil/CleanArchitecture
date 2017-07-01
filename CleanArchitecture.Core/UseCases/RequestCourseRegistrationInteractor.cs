

using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Core.Contracts;
using CleanArchitecture.Core.Dto;

namespace CleanArchitecture.Core.UseCases
{
    public class RequestCourseRegistrationInteractor : IRequestHandler<CourseRegistrationRequestMessage, CourseRegistrationResponseMessage>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IAuthService _authService;
        public RequestCourseRegistrationInteractor(IAuthService authService, IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            _authService = authService;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        public CourseRegistrationResponseMessage Handle(CourseRegistrationRequestMessage message)
        {
            // student must be logged into system
            if (!_authService.IsAuthenticated())
            {
                return new CourseRegistrationResponseMessage(false,null,"Operation failed, not authenticated.");
            }

            // get the student
            var student = _studentRepository.GetById(message.StudentId);

            // save off any failures
            var errors = new List<string>();

            foreach (var c in message.SelectedCourseCodes)
            {
                var course = _courseRepository.GetByCode(c);

                if (!student.RegisterForCourse(course))
                {
                    errors.Add($"unable to register for {course.Code}");
                }
            }

            _studentRepository.Save(student);

            return new CourseRegistrationResponseMessage(!errors.Any(), errors);
        }
    }
}
