

using CleanArchitecture.Core.Contracts;
using CleanArchitecture.Core.Dto;

namespace CleanArchitecture.Core.UseCases
{
    public class RequestCourseRegistrationInteractor : IRequestHandler<CourseRegistrationRequestMessage, CourseRegistrationResponseMessage>
    {
        private readonly IAuthService _authService;
        public RequestCourseRegistrationInteractor(IAuthService authService)
        {
            _authService = authService;
        }

        public CourseRegistrationResponseMessage Handle(CourseRegistrationRequestMessage message)
        {
            // student must be logged into system
            if (!_authService.IsAuthenticated())
            {
                return new CourseRegistrationResponseMessage(false,"Operation failed, not authenticated.");
            }

            return null;
        }
    }
}
