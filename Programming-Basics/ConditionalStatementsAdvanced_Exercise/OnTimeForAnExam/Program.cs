using System;

namespace OnTimeForAnExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinute = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMinute = int.Parse(Console.ReadLine());

            int examTime = examHour * 60 + examMinute;
            int arrivalTime = arrivalHour * 60 + arrivalMinute;

            if (arrivalTime < examTime - 30)
            {
                Console.WriteLine("Early");
                if (arrivalMinute <= examMinute - 1)
                {
                    Console.WriteLine($"{arrivalMinute - examMinute} minutes before the start");
                }
                else if(arrivalHour <= examHour && arrivalHour <= examHour - 1)
                {
                    Console.WriteLine($"{examHour - arrivalHour}:{examMinute - arrivalMinute}0 hours before the start");
                }
                
            }
            else if (arrivalTime <= examTime && arrivalTime >= examTime - 30)
            {
                Console.WriteLine("On time");
                if (arrivalTime >= examTime - 30)
                {
                    Console.WriteLine($"{arrivalMinute - examMinute} minutes before the start");
                }
            }
            else if (arrivalTime > examTime)
            {
                Console.WriteLine("Late");
                if (arrivalHour >= examHour && arrivalMinute > arrivalMinute - 59)
                {
                    Console.WriteLine($"{arrivalTime - examTime} minutes after the start");
                }
                else if (arrivalHour >= examHour - 1)
                {
                    Console.WriteLine($"{arrivalHour - examHour}:{arrivalMinute - examMinute} hours after the start");
                }
            }
        }
    }
}
