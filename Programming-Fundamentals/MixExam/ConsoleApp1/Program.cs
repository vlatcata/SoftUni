using System;
using System.Collections.Generic;
using System.Linq;

namespace Numbers
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> numbers = Console.ReadLine()
					.Split(" ", StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToList();

			double average = numbers.Average();
			var result = numbers
					.OrderByDescending(x => x)
					.Where(x => x > average)
					.Take(5)
					.ToList();
			if (result.Count == 0)
			{
				Console.WriteLine("No");
			}
			else
			{
				Console.WriteLine(string.Join(" ", result));
			}
		}
	}
}