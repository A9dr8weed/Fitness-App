using FitnessApp.BL.Controller;

using System;

namespace FitnessApp.CMD
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;

            Console.WriteLine("Вас вітає додаток Fitness-App");

            Console.WriteLine("Введіть ім'я користувача");
            string name = Console.ReadLine();

            UserController userController = new UserController(name);
            
            if (userController.IsNewUser)
            {
                Console.Write("Введіть стать: ");
                string gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime();
                double weight = ParseDouble("вага");
                double height = ParseDouble("ріст");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Введіть дату народження (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неправильний формат дати");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введіть {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неправильний формат {name}");
                }
            }
        }
    }
}