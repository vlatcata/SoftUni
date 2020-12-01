using System;

namespace FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            double factorialFirstNum = GetFactorial(firstNumber);
            double factorialSecondtNum = GetFactorial(secondNumber);

            double result = factorialFirstNum / factorialSecondtNum;

            Console.WriteLine($"{result:F2}");
        }

        public static double GetFactorial(int number)
        {
            double result = 1;
            while (number != 1)
            {
                result = result * number;
                number = number - 1;
            }
            return result;
        }
    }
}
