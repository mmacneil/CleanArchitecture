 

using CleanArchitecture.Core.Contracts;

namespace CleanArchitecture.Core.Dto
{
    public class CourseRegistrationResponseMessage : ResponseMessage
    {
        public CourseRegistrationResponseMessage(bool success, string message = null) : base(success, message)
        {
        }
    }
}
