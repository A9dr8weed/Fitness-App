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
            ExerciseController exerciseController = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write("Введіть стать: ");
                string gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime("дата народження");
                double weight = ParseDouble("вага");
                double height = ParseDouble("ріст");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine("Що ви хочете зробити?");
                Console.WriteLine("Е - ввести прийом їжі");
                Console.WriteLine("A - ввести вправу");
                Console.WriteLine("Q - вихід");
                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        (Food Food, double Weight) foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (KeyValuePair<Food, double> item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }

                        break;

                    case ConsoleKey.A:
                        (DateTime Begin, DateTime End, Activity Activity) exe = EnterExercise();
                        exerciseController.Add(exe.Activity, exe.Begin, exe.End);

                        foreach (Exercise item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} з {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }

                        break;

                    case ConsoleKey.Q:
                        Environment.Exit(0);

                        break;
                }
            }
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.Write("\nВведіть назву вправи: ");
            string name = Console.ReadLine();

            double energy = ParseDouble("розхід енергії в хвилину");
            DateTime begin = ParseDateTime("початок вправи");
            DateTime end = ParseDateTime("кінець вправи");
            Activity activity = new Activity(name, energy);

            return (begin, end, activity);
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

        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;

            while (true)
            {
                Console.Write($"Введіть {value} (dd.MM.yyyy): ");
                
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неправильний формат {value}");
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