using System;
using System.Linq;

namespace SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] rowData = Console.ReadLine().ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
            bool isSymbol = false;
            string symbol = Console.ReadLine();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col].ToString() == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        isSymbol = true;
                        break;
                    }
                }

                if (isSymbol == true)
                {
                    break;
                }
            }

            if (isSymbol == false)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
            
        }
    }
}
