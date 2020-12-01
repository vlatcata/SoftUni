using System;

namespace Greeting_By_Name
{
	class Program
	{
		static void Main()
		{
			//read a persons name
			//print "Hello, {person's name}"
			string name = Console.ReadLine();
			Console.WriteLine("Hello, " + name + "!");
		}
	}
}
