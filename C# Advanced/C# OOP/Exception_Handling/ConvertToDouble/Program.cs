using System;

namespace ConvertToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            double result;

            try
            {
                result = Convert.ToDouble(word);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
