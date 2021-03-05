using System;

namespace AnimalFarm.Models
{
    public class Chicken
    {
        private const int MinAge = 0;
        private const int MaxAge = 15;

        private string name;
        private int age;

        internal Chicken(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }
                name = value;
            }
        }

        public int Age
        {
            get => age;

            private set
            {
                if (value < MinAge || value > MaxAge)
                {
                    throw new ArgumentException($"Age should be between {MinAge} and {MaxAge}.");
                }
                age = value;
            }
        }

        public double ProductPerDay
        {
			get
			{
                if (Age >= 0 && Age <= 3)
                {
                    return 1.5;
                }
                else if (Age >= 4 && Age <= 7)
                {
                    return 2;
                }
                else if (Age >= 8 && Age <= 11)
                {
                    return 1;
                }

                return 0.75;
            }
        }
    }
}
