using System;

namespace Inch__to_cm_Converter
{
	class Program
	{
		static void Main()
		{
			double num = double.Parse(Console.ReadLine());
			double inches = num;
			double cm = 2.54 * inches;
			Console.WriteLine(cm);
		}
	}
}
