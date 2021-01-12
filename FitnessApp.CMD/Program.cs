using FitnessApp.BL.Controller;
using FitnessApp.BL.Model;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Threading;

namespace FitnessApp.CMD
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US"); // uk-UA, en-US
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            ResourceManager resourceManager = new ResourceManager("FitnessApp.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture));

            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            string name = Console.ReadLine();

            UserController userController = new UserController(name);
            EatingController eatingController = new EatingController(userController.CurrentUser);

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

            Console.WriteLine("Що ви хочете зробити?");
            Console.WriteLine("Е - ввести прийом їжі");
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.E)
            {
                (Food Food, double Weight) foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach (KeyValuePair<Food, double> item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введіть ім'я продукта: ");
            string food = Console.ReadLine();

            double callories = ParseDouble("калорійність");
            double prot = ParseDouble("білки");
            double fats = ParseDouble("жири");
            double carbs = ParseDouble("вуглеводи");

            double weight = ParseDouble("вага порції");

            Food product = new Food(food, callories, prot, fats, carbs);

            return (Food: product, Weight: weight);
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
                    Console.WriteLine($"Неправильний формат поля {name}");
                }
            }
        }
    }
}