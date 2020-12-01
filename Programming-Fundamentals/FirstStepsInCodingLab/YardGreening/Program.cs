using System;

namespace YardGreening
{
	class Program
	{
		static void Main()
		{
			//read yard space
			//claculate price without discount (* 7.61)
			//calculate discount (priceWithoutDiscount *0/18)
			//subtract discount from price without discount
			//print

			double yard = double.Parse(Console.ReadLine());
			double priceWithoutDiscount = yard * 7.61;
			double discount = priceWithoutDiscount * 0.18;
			double finalPrice = priceWithoutDiscount - discount;

			Console.WriteLine("The final price is: " + finalPrice + " lv.");
			Console.WriteLine("The discount is: " + discount + " lv.");

		}
	}
}
