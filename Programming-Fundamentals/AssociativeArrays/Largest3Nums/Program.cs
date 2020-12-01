using System;
using System.Linq;

namespace Largest3Nums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .OrderByDescending(n => n)
                .ToArray();
            int count = nums.Length >= 3 ? 3 : nums.Length;
            for (int i = 0; i < count; i++)
            {
                Console.Write($"{nums[i]} ");
            }      
        }
    }
}
