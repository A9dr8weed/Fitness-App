using FitnessApp.BL.Controller;

using System;

namespace FitnessApp.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас вітає додаток Fitness-App");
            
            Console.WriteLine("Введіть ім'я користувача");
            string name = Console.ReadLine();

            Console.WriteLine("Введіть стать");
            string gender = Console.ReadLine();

            Console.WriteLine("Введіть дату народження");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Введіть вагу");
            double weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Введіть ріст");
            double height = double.Parse(Console.ReadLine());

            UserController userController = new UserController(name, gender, birthDate, weight, height);
            userController.Save();
        }
    }
}