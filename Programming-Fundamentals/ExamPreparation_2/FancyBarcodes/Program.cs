using System;
using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"@\#+[A-Z][A-Za-z0-9]{4,}[A-Z]@\#+";
            Regex regex = new Regex(pattern);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = regex.Match(input);

                if (match.Success)
                {
                    string barcode = match.Value;
                    string temp = "";
                    for (int j = 0; j < barcode.Length; j++)
                    {
                        if (char.IsDigit(barcode[j]))
                        {
                            temp += barcode[j];
                        }
                    }

                    if (temp == "")
                    {
                        Console.WriteLine($"Product group: 00");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: {temp}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
