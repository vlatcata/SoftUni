using System;

namespace PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintTriangles(n);
        }

        static void PrintTriangles(int n)
        {
            for (int line = 1; line <= n; line++)
            {
                Console.WriteLine(line);
            }
            for (int line = n - 1; line >= n; line--)
            {
                Console.WriteLine(line);
            }
        }
    }
}
