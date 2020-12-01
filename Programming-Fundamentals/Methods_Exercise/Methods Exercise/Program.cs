using System;

namespace Methods_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = { 1, 2, 3, 4, 5 };
            ChangeArray(myArray);
            Console.WriteLine(string.Join(" ", myArray));
        }
        static void ChangeArray(int[] array)
        {
            array[0] = 10;
            array[1] = 20;
            array[2] = 30;
            array[3] = 40;
            array[4] = 50;
        }
    }
}
