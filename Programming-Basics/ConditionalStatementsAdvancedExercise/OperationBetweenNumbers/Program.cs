using System;

namespace OperationBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            string operatorr = Console.ReadLine();

            string printResult = "";
            double result = 0.0;

            switch (operatorr)
            {
                case "+":
                    result = n1 + n2;
                    if (result % 2 == 0)
                    {
                        printResult = $"{n1} {operatorr} {n2} = {result} - even";
                    }
                    else
                    {
                        printResult = $"{n1} {operatorr} {n2} = {result} - odd";
                    }
                    break;
                case "-":
                    result = n1 - n2;
                    if (result % 2 == 0)
                    {
                        printResult = $"{n1} {operatorr} {n2} = {result} - even";
                    }
                    else
                    {
                        printResult = $"{n1} {operatorr} {n2} = {result} - odd";
                    }

                    break;
                case "*":
                    result = n1 * n2;
                    if (result % 2 == 0)
                    {
                        printResult = $"{n1} {operatorr} {n2} = {result} - even";
                    }
                    else
                    {
                        printResult = $"{n1} {operatorr} {n2} = {result} - odd";
                    }

                    break;
                case "/":
                    if (n2 == 0)
                    {
                        printResult = $"Cannot divide {n1} by zero";
                    }
                    else
                    {
                        result = (double)n1 / n2;
                        printResult = $"{n1} {operatorr} {n2} = {result:F2}";
                    }

                    break;
                case "%":
                    if (n2 == 0)
                    {
                        printResult = $"Cannot divide {n1} by zero";
                    }
                    else
                    {
                        result = n1 % n2;
                        printResult = $"{n1} {operatorr} {n2} = {result}";
                    }

                    break;

            }
            Console.WriteLine(printResult);
        }
    }
}
