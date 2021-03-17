using System;

namespace AuthorProblem
{
    [Author("Vladi")]
    public class StartUp
    {
        [Author("Pak Vladi!")]
        public static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}
