using System;

namespace PetShop
{
	class Program
	{
		static void Main()
		{
			int broiKucheta = int.Parse(Console.ReadLine());
			int jivotniNaSuseda = int.Parse(Console.ReadLine());
			double krainaSuma = broiKucheta * 2.50 + jivotniNaSuseda * 4;
			Console.WriteLine(krainaSuma + " lv.");

		}
	}
}
