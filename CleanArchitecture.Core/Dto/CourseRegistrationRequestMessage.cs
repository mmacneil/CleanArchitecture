 

using System.Collections.Generic;
using CleanArchitecture.Core.Contracts;

namespace CleanArchitecture.Core.Dto
{
    public class CourseRegistrationRequestMessage : IRequest<CourseRegistrationResponseMessage>
    {
        public int StudentId { get; private set; }
        public List<string> SelectedCourseCodes { get; private set; }

        public CourseRegistrationRequestMessage(int studentId,List<string> selectedCourseCodes)
        {
            StudentId = studentId;
            SelectedCourseCodes = selectedCourseCodes;
        }
    }
}
