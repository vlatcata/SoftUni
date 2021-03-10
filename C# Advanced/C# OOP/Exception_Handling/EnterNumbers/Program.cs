using System;

namespace EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            int[] numbers = new int[10];

            try
            {
                ReadNumber(start, end, numbers);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                ReadNumber(start, end, numbers);
            }
        }

        private static void ReadNumber(int start, int end, int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Num {i}: ");
                numbers[i] = int.Parse(Console.ReadLine());
                
                if (numbers[i] < start || numbers[i] > end)
                {
                    throw new InvalidOperationException("Invalid input");
                }
            }         
        }
    }
}
