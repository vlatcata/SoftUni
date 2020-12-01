using System;

namespace Project_Creation
{
	class Program
	{
		static void Main()
		{
			string ime = Console.ReadLine();
			int broiProekti = int.Parse(Console.ReadLine());
			int broiChasove = broiProekti * 3;
			Console.WriteLine("The architect " + ime + " will need " + broiChasove + " hours to complete " + broiProekti + " project/s.");
		}
	}
}
