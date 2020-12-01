using System;

namespace AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int sum = Sum(firstNumber, secondNumber, thirdNumber);

            Console.WriteLine(sum);
        }

        private static int Sum(int firstNumber, int secondNumber, int thirdNumber)
        {
            int sumFirstAndSecond = firstNumber + secondNumber;
            return AddAndSubtract(sumFirstAndSecond, thirdNumber);
        }

        private static int AddAndSubtract(int sumFirstAndSecond, int thirdNumber)
        {
            return sumFirstAndSecond - thirdNumber;
        }
    }
}
