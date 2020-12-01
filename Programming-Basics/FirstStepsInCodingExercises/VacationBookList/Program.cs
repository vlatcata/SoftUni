using System;

namespace VacationBookList
{
    class Program
    {
        static void Main()
        {
            int sheets = int.Parse(Console.ReadLine());
            double sheetsPerHour = double.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            double totalTime = sheets / sheetsPerHour;
            double result = totalTime / days;
            Console.WriteLine(result);
             
        }
    }
}
