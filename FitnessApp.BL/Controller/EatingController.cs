﻿using FitnessApp.BL.Model;

using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.BL.Controller
{
    public class EatingController : ControllerBase
    {
        private const string FOODS_FILE_NAME = "foods.dat";
        private const string EATINGS_FILE_NAME = "eatings.dat";

        private readonly User User;
        public List<Food> Foods { get; }
        public Eating Eating { get; }

        public EatingController(User user)
        {
            User = user ?? throw new ArgumentNullException("Користувач не може бути пустим", nameof(user));

            Foods = GetAllFoods();
            Eating = GetEating();
        }

        public void Add(Food food, double weight)
        {
            Food product = Foods.SingleOrDefault(x => x.Name == food.Name);

            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }

        private Eating GetEating()
        {
            return Load<Eating>(EATINGS_FILE_NAME) ?? new Eating(User);
        }

        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();
        }

        private void Save()
        {
            Save(FOODS_FILE_NAME, Foods);
            Save(EATINGS_FILE_NAME, Eating);
        }
    }
}