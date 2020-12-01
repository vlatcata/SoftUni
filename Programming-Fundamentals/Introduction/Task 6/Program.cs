using System;

namespace Task_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int number = input;

            int currentNumber = 0;
            int factorialSum = 0;

            while (number != 0)
            {
                currentNumber = number % 10;
                number /= 10;

                int factorial = 1;

                for (int i = 1; i <= currentNumber; i++)
                {
                    factorial *= i;
                }

                factorialSum += factorial;
            }
            string result = "";
            if (input == factorialSum)
            {
                result = "yes";
            }
            else
            {
                result = "no";
            }
            Console.WriteLine(result);
        }
    }
}
