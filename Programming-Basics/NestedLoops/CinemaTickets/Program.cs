using System;

namespace CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            int standardTicket = 0;
            int studentTicket = 0;
            int kidTicket = 0;

            string movie = Console.ReadLine();

            while (movie != "Finish")
            {
                int avaliableSeats = int.Parse(Console.ReadLine());
                int currentSeats = 0;
                string ticketType = Console.ReadLine();
                while (ticketType != "End" && currentSeats < avaliableSeats)
                {
                    switch (ticketType)
                    {
                        case "standard":
                            standardTicket++;
                            currentSeats++;
                            break;
                        case "student":
                            studentTicket++;
                            currentSeats++;
                            break;
                        case "kid":
                            kidTicket++;
                            currentSeats++;
                            break;
                        
                    }

                    ticketType = Console.ReadLine();
                }
                Console.WriteLine($"{movie} - {(double)currentSeats / (double)avaliableSeats}% full.");
                movie = Console.ReadLine();
            }
            int totalTicketsCount = studentTicket + standardTicket + kidTicket;
            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{(double)studentTicket / totalTicketsCount * 100:f2}% student tickets.");
            Console.WriteLine($"{(double)standardTicket / totalTicketsCount * 100:f2}% standard tickets.");
            Console.WriteLine($"{(double)kidTicket / totalTicketsCount * 100:f2}% kids tickets.");
        }
    }
}
