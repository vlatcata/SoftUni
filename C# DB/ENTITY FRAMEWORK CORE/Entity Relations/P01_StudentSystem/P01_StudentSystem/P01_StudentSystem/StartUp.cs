using System;
using P01_StudentSystem.Data;

namespace P01_StudentSystem
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StudentSystemContext db = new StudentSystemContext();

            db.Database.EnsureCreated();

            Console.WriteLine("Db was created");

            db.Database.EnsureDeleted();
        }
    }
}
