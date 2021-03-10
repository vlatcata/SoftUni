using System;
using System.Collections.Generic;
using System.Text;

namespace ValidPerson
{
    class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstname, string lastname, int age)
        {
            FirstName = firstname;
            LastName = lastname;
            Age = age;
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "The first name cannot be null or empty.");
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "The last name cannot be null or empty.");
                }
                lastName = value;
            }
        }

        public int Age
        {
            get => age;
            set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException("value", "Age should be in the range [0 ... 120].");
                }
                age = value;
            }
        }
    }
}
