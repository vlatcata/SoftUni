using System;

namespace Inch__to_cm_Converter
{
	class Program
	{
		static void Main()
		{
			Console.WriteLine("Write username: ");
			string username = Console.ReadLine();
			Console.WriteLine("Write password: ");
			string password = Console.ReadLine();

			while (username != "Vladi")
			{
				string user = Console.ReadLine();
				Console.WriteLine("Wrong username or password! ");
				break;
			}
			while (password != "vlatcata")
			{
				string pass = Console.ReadLine();
				Console.WriteLine("Wrong username or password! ");
				break;
			}
			if (username == "Vladi" && password == "vlatcata")
			{
				Console.WriteLine("You are logged in ");
			}
		}
	}
}