 

 

namespace CleanArchitecture.ConsoleApp.Presentation
{
    public class CourseRegistrationResponseViewModel
    {
        public bool Success { get; private set; }
        public string ResultMessage { get; private set; }

        public CourseRegistrationResponseViewModel(bool success, string resultMessage)
        {
            Success = success;
            ResultMessage = resultMessage;
        }
    }
}
