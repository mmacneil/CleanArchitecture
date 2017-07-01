

using System;
using System.Collections.Generic;
using CleanArchitecture.ConsoleApp.Gateways;
using CleanArchitecture.ConsoleApp.Presentation;
using CleanArchitecture.Core.Dto;
using CleanArchitecture.Core.UseCases;

namespace CleanArchitecture.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // init gateways, in a real app these would get wired up via IoC
            var authService = new AuthService();
            var courseRepository = new CourseRepository();
            var studentRepository = new StudentRepository();

            var courses = courseRepository.GetAll();

            string userInput;
            do
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Course Registration");
                Console.WriteLine();

                foreach (var c in courses)
                {
                    Console.WriteLine($"{c.Code} - {c.Description} - Starts: {c.StartDate:MMMM dd, yyyy}");
                }
         
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Enter course code or 'quit':");
                userInput = Console.ReadLine();

                if (userInput != "quit")
                {
                    //*************************************************************************************************
                    // Here we're connecting our app framework layer with our Use Case Interactors
                    // This would typically go in a Controller Action in an MVC context or ViewModel in MVVM etc.
                    //*************************************************************************************************
                    // 1. instantiate Course Registration Use Case injecting Gateways implemented in this layer
                    var courseRegistraionRequestUseCase = new RequestCourseRegistrationInteractor(authService, studentRepository, courseRepository);

                    // 2. create the request message passing with the target student id and a list of selected course codes 
                    var useCaseRequestMessage = new CourseRegistrationRequestMessage(1, new List<string> { userInput.ToUpper() });

                    // 3. call the use case and store the response
                    var responseMessage = courseRegistraionRequestUseCase.Handle(useCaseRequestMessage);

                    // 4. use a Presenter to convert the use case response to a user friendly ViewModel
                    var courseRegistraionResponsePresenter = new CourseRegistrationResponsePresenter();
                    var vm = courseRegistraionResponsePresenter.Handle(responseMessage);

                    Console.Clear();

                    // render results
                    if (vm.Success)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine();
                    Console.WriteLine(vm.ResultMessage);
                    Console.WriteLine();
                }
            } while (userInput != "quit");
        }
    }
}