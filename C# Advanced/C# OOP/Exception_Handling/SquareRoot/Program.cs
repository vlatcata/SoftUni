using System;

namespace SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            CalculateSquareRoot(n);
        }

        private static void CalculateSquareRoot(int n)
        {
            
            try
            {
                int root = n * n;
                if (n <= 0)
                {
                    throw new InvalidOperationException("Invalid number");
                }
                Console.WriteLine(root);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
