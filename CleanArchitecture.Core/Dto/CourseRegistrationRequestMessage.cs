 

using System.Collections.Generic;
using CleanArchitecture.Core.Contracts;

namespace CleanArchitecture.Core.Dto
{
    public class CourseRegistrationRequestMessage : IRequest<CourseRegistrationResponseMessage>
    {
        public List<string> SelectedCourseCodes { get; private set; }

        public CourseRegistrationRequestMessage(List<string> selectedCourseCodes)
        {
            SelectedCourseCodes = selectedCourseCodes;
        }
    }
}
