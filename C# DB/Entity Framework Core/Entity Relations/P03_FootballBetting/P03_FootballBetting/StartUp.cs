using System;
using P03_FootballBetting.Data;

namespace P03_FootballBetting
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Rebuild project before working on it

            FootballBettingContext dbContext = new FootballBettingContext();

            dbContext.Database.EnsureCreated();

            Console.WriteLine("Db was Created");

            dbContext.Database.EnsureDeleted();
        }
    }
}
