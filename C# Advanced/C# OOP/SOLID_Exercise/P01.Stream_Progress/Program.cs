using System;
using System.Threading;
using System.Linq;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            IStreamable file = new File("ivan", 100, 10);
            StreamProgressInfo proccessFile = new StreamProgressInfo(file);
            int progress = 0;
            Console.WriteLine("Download is at:");
            while (progress <= 90)
            {
                progress += proccessFile.CalculateCurrentPercent();
                Console.WriteLine($"{progress}%");
                Thread.Sleep(1000);
            }
            Console.WriteLine("Download finished!");
        }
    }
}
